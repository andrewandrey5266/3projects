using System.Collections.Generic;
using System;

namespace BlackJack.Models
{

    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<int> Cards { get; set; }
        public Func<bool> IsPassing { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<int>();
            IsPassing = () => false;
        }
        public Player(string name, Func<bool> condition) : this(name)
        {
            IsPassing = condition;
        }
    }
}
