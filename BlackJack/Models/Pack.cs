using System.Collections.Generic;
namespace BlackJack.Models
{
    class Pack
    {
        public int[] cards;
        public PackType packType;
  
        public Pack(PackType packType)
        {
            this.packType = packType;
            cards = (int[]) BJSystem.GetCardDeck(packType);           
        }       
    }
}
