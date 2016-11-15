using System;
using BlackJack.Models;

namespace BlackJack.Functions
{
    class PackService
    {
        public  Pack pack { get; }
        private Random rand = new Random();

        public PackService(Pack pack)
        {
            this.pack = pack;
        }
        public int PopCard()
        {
            if (pack.cards.Length == 0)
                ChangePack();

            int index = rand.Next(0, pack.cards.Length - 1);
            int value = pack.cards[index];

            //deleting of taken card from the pack
            int[] temp = new int[pack.cards.Length - 1];
            Array.Copy(pack.cards, temp, index);
            Array.Copy(pack.cards, index + 1, temp, index, pack.cards.Length - index - 1);
            pack.cards = temp;

            return value;
        }
        public void ChangePack()
        {
            pack.cards = (int[])BJSystem.GetCardDeck(pack.packType);
        }
    }
}
