using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameSession(PackType.small, 
                new ConsoleStream(), 
                new Player("Player1")).StartGame();

            Console.ReadKey();
        }
    }
    
}
