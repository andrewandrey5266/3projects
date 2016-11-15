using System.Collections.Generic;
namespace BlackJack.Models
{
    class Pack
    {
        public int[] cards;
        public Dictionary<int, string> numToCardname { get; private set; }
        public PackType packType;
  
        public Pack(PackType packType)
        {
            this.packType = packType;
            cards = (int[]) BJSystem.GetCardDeck(packType);
            numToCardname = (Dictionary<int,string>) BJSystem.GetCardDict(packType);
        }
       
    }
}
