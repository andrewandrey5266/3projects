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
        public Dealer dealer;
        public List<Player> players;// dealer, player1, player2, ...
        public IInputOutput<string,int> cs;
        public GameSession(PackType packType, params Player[] players)
        {
            cs = new ConsoleStream<string,int>(); // init io stream
            this.dealer = new Dealer(packType);
            this.players = new List<Player>();

            this.players.Add(dealer);
            this.players.AddRange(players);

            foreach (var player in this.players)
                dealer.DistributeCards.Add(player);

            // Interactive start
        }
        public void PrepareForNewGame()
        {
            foreach(var player in players)
                player.Init();            
            dealer.Pack.ChangePack();
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
            else if (response == 2)
                EndGame();
        }
        public void DoGameIteration()
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
            else if (response == 2)
            {
                players[1].IsPassing = () => true;
                while (dealer.HandOutCards() == false) ;
                PostIteration();
                
            }
        }
        public void PostIteration()
        {
            cs.Output(dealer.ChooseWinner(players));
            cs.Output("Try again?\n1 - Yes\n2 - No\n");

            int response = cs.Input();

            if (response == 1)
            {
                PrepareForNewGame();
                StartGame();
            }
            else if (response == 2)
                EndGame();
        }
        public void EndGame()
        {

            Output("Thx for your gems");
        }       
    }

    
    class ConsoleStream<T, K> : IInputOutput<T, K>
    {
        Func<string> InputStream = Console.ReadLine;
        Action<string> OutputStream = Console.Write;
        public K Input()
        {
            while (true)
            {
                string str = InputStream();

                int response;
                int.TryParse(str, out response);

                if (response != 1 && response != 2)
                {
                    Output("Wrong input, try again!\n");
                    continue;
                }
                else
                    return response;
            }
        }
        public void Output(T str)
        {
            OutputStream(str);
        }
    }
   
    interface IInputOutput<T, K>
    {
        void Output(T str);
        K Input();
    }
}
