using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public List<int> Cards { get; private set; }
        private bool pass;

        public bool Pass
        {
            get { return pass; }
            set { pass = !pass ? value : pass; }
        }
        public Player(string name)
        {
            Name = name;
            Cards = new List<int>();         
        }
        public virtual void AddCard(int card)
        {
            Cards.Add(card);
            Score += card;            
        }
        
    }
}
