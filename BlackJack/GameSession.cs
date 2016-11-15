using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Functions;
using BlackJack.Models;
namespace BlackJack
{    
    class GameSession
    {
        // ?? Initialize here or in constructor ??
        private Dealer dealer;
        private List<Player> players = new List<Player>();// dealer, player1, player2, ...
        private ConsoleStream consoleStream;
        //- Services     
        private DealerService dealerService;
        //

        public GameSession(ConsoleStream IOStream, PackType packType, params Player [] player)
        {
            consoleStream = IOStream; // init io stream
            this.dealer = new Dealer(packType);
            
            this.players.Add(dealer);
            this.players.AddRange(player);
            
            // add services
            dealerService = new DealerService(dealer, player);
            //            
        }
       
        //into separate class
              
        public void StartGame()
        {
            //-Get
            consoleStream.Output("Welcome to Black Jack game\n");
            consoleStream.Output("1 - Start Game\n2 - Quit Game\n");
            int response = consoleStream.Input();

            //-Post
            if (response == 1)
                DoGameIteration();
            if (response == 2)
                EndGame();
            
        }
        [Obsolete("Use only for debugging")]
        private void info()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in players)
            {                
                sb.Append("                            Name: " + c.Name + "\n");
                sb.Append("                            Hash: " + c.GetHashCode()+"\n");
                sb.Append("                            Score: " + c.Score + "\n");
                sb.Append("                            Passig: " + c.IsPassing() + "\n");
                sb.Append("                            Cards: " + string.Join(" ", c.Cards) + "\n");
                sb.Append("                            --------------------\n");            
            }
            Console.WriteLine(sb.ToString());
        }
        private void DoGameIteration()
        {           
           
            //-Get
            consoleStream.Output("1 - TakeCard\n2 - Pass\n");
            int response = consoleStream.Input();
           
            //-Post
            if (response == 1)
            {
                dealerService.HandOutCards();
                                
                consoleStream.Output(string.Format("You've pulled {0}\nYour current score {1}\n",
                    BJSystem.GetCardName(players[1].Cards.Last()), 
                    players[1].Score));

                DoGameIteration();
                return;          
            }
            if (response == 2)
            {
                players[1].IsPassing = () => true;

                int i = 0;
                while (!dealerService.HandOutCards()) ;

                #region old debug code  
                //    == false && i < 10)
                //{
                //    consoleStream.Output(string.Format("dealer pull card score={0}, last card={1}\n", 
                //        dealer.Score,
                //        dealer.Cards.Last()));
                //    i++;
                //}                
                #endregion

                PostIteration();
                return;
            }


        }
        private void PostIteration()
        {
            consoleStream.Output(dealerService.GetRateList(players));
            consoleStream.Output("Try again?\n1 - Yes\n2 - No\n");

            int response = consoleStream.Input();

            if (response == 1)
            {
                PrepareForNewGame();
                StartGame();
            }
            if (response == 2)
                EndGame();
        }
        private void EndGame()
        {
            consoleStream.Output("Thx for your gems");
        }

        private void PrepareForNewGame()
        {
            dealerService.InitAll();
            
        }
    }

    
  
   

}
