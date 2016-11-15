using System.Collections.Generic;

namespace BlackJack.Models
{

    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<int> Cards { get; set; }
        public bool IsPassing { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<int>();
        }
    }
}
