using System.Collections.Generic;
using System;
using System.Linq;
namespace BlackJack.Models
{

    class Player : ICloneable
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

        public object Clone()
        {
            return new Player(this.Name)
            {
                Score = this.Score,
                Cards = new List<int>(this.Cards.Select(p => p)),
                IsPassing = this.IsPassing
            };
        }
    }
}
