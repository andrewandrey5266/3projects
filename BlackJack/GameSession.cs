using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{    
    class GameSession
    {
        // ?? Initialize here or in constructor ??
        private Dealer dealer;
        private List<Player> players;// dealer, player1, player2, ...
        private IInputOutput cs;
        public GameSession(PackType packType, IInputOutput IOStream, params Player[] players)
        {
            cs = IOStream; // init io stream
            this.dealer = new Dealer(packType);
            this.players = new List<Player>();

            this.players.Add(dealer);
            this.players.AddRange(players);

            foreach (var player in this.players)
                dealer.DistributeCards.Add(player);

            // Interactive start
        }
       
        //into separate class
              
        public void StartGame()
        {
            //-Get
            cs.Output("Welcome to Black Jack game\n");
            cs.Output("1 - Start Game\n2 - Quit Game\n");
            int response = cs.Input();

            //-Post
            if (response == 1)
                DoGameIteration();
            if (response == 2)
                EndGame();
            
        }
        private void DoGameIteration()
        {
            //-Get
            cs.Output("1 - TakeCard\n2 - Pass\n");
            int response = cs.Input();

            //-Post
            if (response == 1)
            {
                dealer.HandOutCards();
                                
                cs.Output(string.Format("You've pulled {0}\nYour current score {1}\n",
                    BJSystem.GetCardName(players[1].Cards.Last()), players[1].Cards.Sum()));

                DoGameIteration();
                
            }
            if (response == 2)
            {
                players[1].IsPassing = () => true;
                while (dealer.HandOutCards() == false) ;
                PostIteration();
                
            }
        }
        private void PostIteration()
        {
            cs.Output(dealer.ChooseWinner(players));
            cs.Output("Try again?\n1 - Yes\n2 - No\n");

            int response = cs.Input();

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
            cs.Output("Thx for your gems");
        }

        private void PrepareForNewGame()
        {
            foreach (var player in players)
                player.Init();
            dealer.Pack.ChangePack();
        }
    }

    
    class ConsoleStream : IInputOutput
    {        
        public int Input()
        {
            while (true)
            {
                string str = Console.ReadLine();

                int response;
                int.TryParse(str, out response);

                if (response != 1 && response != 2)
                {
                    Console.Write("Wrong input, try again!\n");
                    continue;
                }
                else
                    return response;
            }
        }
        public void Output(string str)
        {
            Console.Write(str);
        }
    }
   
    interface IInputOutput
    {
        void Output(string str);
        int Input();
    }
}
