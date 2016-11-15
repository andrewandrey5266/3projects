using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameSession(new ConsoleStream(), 
                PackType.small,                 
                new Player("Player1")).StartGame();

            Console.ReadKey();
        }
    }
    
}
