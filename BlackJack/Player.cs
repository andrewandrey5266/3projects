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
    class Player : IGetCard, IComparable<Player>
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

      
        public int CompareTo(Player other)
        {
            if (this == null || other == null)
                return 0;

            //21 - 21
            //< 21 - < 21
            //> 21 - > 21
            if (this.Score == other.Score)
            {
                if (this.Cards.Count < other.Cards.Count)
                    return 1;
                else if (this.Cards.Count > other.Cards.Count)
                    return -1;
                else return 0;
            }

            //21 - > 21
            //21 - < 21
            //< 21 - > 21
            if ((this.Score == 21 && other.Score != 21) ||
                (this.Score > 21 && other.Score > 21))
                return 1;

            //> 21 - 21
            //< 21 - 21
            //> 21 - < 21
            if ((other.Score == 21 && this.Score != 21) ||
                (other.Score > 21 && this.Score > 21))
                return -1;

            throw new Exception("missing if statement");
        }

    }
}
