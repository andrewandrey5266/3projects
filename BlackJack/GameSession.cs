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

        public GameSession(PackType packType, ConsoleStream IOStream, Player player)
        {
            consoleStream = IOStream; // init io stream
            this.dealer = new Dealer(packType);
            
            this.players.Add(dealer);
            this.players.Add(player);
            
            // add services
            dealerService = new DealerService(dealer,
                                             new PlayerService(player));
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
                    BJSystem.GetCardName(players[1].Cards.Last()), players[1].Cards.Sum()));

                DoGameIteration();                
            }
            if (response == 2)
            {
                players[1].IsPassing = true;
                int i = 0;
                while (dealerService.HandOutCards() == false && i < 10)
                {
                    consoleStream.Output(string.Format("dealer pull card score={0}, last card={1}\n", 
                        dealer.Score,
                        dealer.Cards.Last()));
                    i++;
                }
                PostIteration();
            }


        }
        private void PostIteration()
        {
            consoleStream.Output(dealerService.ChooseWinner(players));
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
