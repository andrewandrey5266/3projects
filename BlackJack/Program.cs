using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static int InputValide(string str)
        {
            int response;
            int.TryParse(str, out response);
            return response;
        }
        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to Black Jack game");
            while (true)
            {
                // MAIN MENU  ------------------------------------
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1 - Start a game");
                Console.WriteLine("2 - Exit");
                
                // USER CHOOSE -------------------------------------
                int response = InputValide(Console.ReadLine());
                if (response != 1 && response != 2)                
                {                   
                   Console.WriteLine("Wrong input data, try again");
                    continue;
                }
                if (response == 2) return;

               // GAME PROCESS -------------------------------------
                Dealer dealer = new Dealer();
                Player player = new Player("Player1");
                List<Player> players = new List<Player>(new Player[] { dealer, player });
                while (true)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("1 - Take a card");
                    Console.WriteLine("2 - See result");
                    
                    int temp1 = InputValide(Console.ReadLine());
                   
                    if (temp1 == 1)
                    {
                        dealer.TakeCard(players);
                        //Console.WriteLine("Cards are taken");

                        Console.WriteLine("You've pulled card : {0}", dealer.GetCardName (player.Cards[player.Cards.Count - 1]));
                        Console.WriteLine("Your current score : {0}", player.Score);
                    }else if(temp1 == 2)

                    {
                        player.Pass = true;
                        // let other players pull their cards
                        while (!dealer.TakeCard(players));
                        //    
                        Console.WriteLine("-----------------------------------");
                        foreach(var c  in players)
                            Console.WriteLine("Score of {0} : {1}", c.Name, c.Score);
                        
                        // result 
                        Console.WriteLine("\nResult : {0}", dealer.ChooseWinner(dealer, player));
                        // 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input data, try again");
                        continue;
                    }
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine("Do you want to try again?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2 - No");

                int temp2 = InputValide(Console.ReadLine());
                if (temp2 == 2)
                    break;
                else
                    continue;
            }
            Console.WriteLine("Thx for you attention!");
            Console.ReadKey();
        }
    }
}
