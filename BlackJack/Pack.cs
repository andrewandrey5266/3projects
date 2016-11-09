using System.Collections.Generic;
using System;
namespace BlackJack
{
    class Pack
    {
        private int[] cards;
        private Random rand = new Random();

        public Dictionary<int, string> numToCardname { get; private set; }
        
        public Pack()
        {
            #region initialize nums
            cards = new int[]
                 {
                     2,2,2,2,
                     3,3,3,3,
                     4,4,4,4,
                     6,6,6,6,
                     7,7,7,7,
                     8,8,8,8,
                     9,9,9,9,
                     10,10,10,10,
                     11,11,11,11
                 };
            #endregion

            #region initialize dictionary
            numToCardname = new Dictionary<int, string>();
            numToCardname.Add(2, "Jack");
            numToCardname.Add(3, "Queen");
            numToCardname.Add(4, "King");
            numToCardname.Add(5, "Five");
            numToCardname.Add(6, "Six");
            numToCardname.Add(7, "Seven");
            numToCardname.Add(8, "Eight");
            numToCardname.Add(9, "Nine");
            numToCardname.Add(10, "Ten");
            numToCardname.Add(11, "Ace");
            #endregion
        }
        public int PopCard()
        {
            if (cards.Length == 0)
                throw new Exception("No cards left");

            int index = rand.Next(0, cards.Length - 1);
            int value = cards[index];

            //deleting of taken card from the pack
            int[] temp = new int[cards.Length - 1];
            Array.Copy(cards, temp, index);
            Array.Copy(cards, index + 1, temp, index, cards.Length - index - 1);
            cards = temp;

            return value;
        }
    }
}
