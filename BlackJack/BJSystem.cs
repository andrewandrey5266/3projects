using System.Collections.Generic;
using System;

namespace BlackJack
{
    public enum PackType
    {
        big = 52,
        small = 36
    }
    static class BJSystem
    {     
        static int[] cardDeck36;
        static Dictionary<int, string> cardDictionary36;

        static int[] cardDeck52;
        static Dictionary<int, string> cardDictionary52;


        static BJSystem()
        {
            string[] cardNames36 = { "Jack", "Queen", "King", "Six", "Seven", "Eight", "Nine", "Ten", "Ace" };
            int[] cardValues36 = { 2, 3, 4, 6, 7, 8, 9, 10, 11 };

            #region initialize decks

            var temp = new List<int>();

            for (int i = 0; i < 4; i++)
                foreach(var c  in cardValues36)
                    temp.Add(c);

            cardDeck36 = temp.ToArray();

            #endregion

            #region initialize dictionaries    

            cardDictionary36 = new Dictionary<int, string>();
            for (int i = 0; i < cardValues36.Length; i++)
                cardDictionary36.Add(cardValues36[i], cardNames36[i]);

            #endregion
        }

        public static IEnumerable<int> GetCardDeck(PackType packType)
        {
            if (packType == PackType.big)
                return cardDeck52;
            else
                return cardDeck36;
        }
        public static IDictionary<int, string> GetCardDict(PackType packType)
        {
            if (packType == PackType.big)            
               return cardDictionary52;            
            else
                return cardDictionary36;
        }

        public static string GetCardName(int value)
        {
            return cardDictionary36[value];
        }
              
    }
}
