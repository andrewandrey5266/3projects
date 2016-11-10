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
            var game = new GameSession(PackType.small, new Player("Player1"));
            game.StartGame();
        }
    }
    
}
