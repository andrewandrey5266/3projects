using System.Collections.Generic;
using System;
namespace BlackJack
{
    class Pack
    {
        private int[] cards;
        public Dictionary<int, string> numToCardname { get; private set; }
        public PackType packType;
        private Random rand = new Random();        
        
        public Pack(PackType packType)
        {
            this.packType = packType;
            cards = (int[]) BJSystem.GetCardDeck(packType);
            numToCardname = (Dictionary<int,string>) BJSystem.GetCardDic(packType);
        }
        public int PopCard()
        {
            if (cards.Length == 0)
                cards = (int[]) BJSystem.GetCardDeck(packType);

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
