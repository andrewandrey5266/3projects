using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IGetCard
    {
        void AddCard(int value);
    }
    class Player : IGetCard
    {

        public string Name { get; private set; }
        public int Score { get; private set; }
        public List<int> Cards { get; private set; }

       
        public Func<bool> IsPassing;

        public Player(string name)
        {
            Name = name;
            Init();
        }
       
        public void AddCard(int value)
        {
            Score += value;
            Cards.Add(value);           
        }

        public virtual void Init()
        {
            IsPassing = () => false;
            Score = 0;
            Cards = new List<int>();
        }
    }
}
