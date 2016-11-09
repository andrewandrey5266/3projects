using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{   
    class Dealer : Player
    {
        Pack pack;

        public Dealer() : base("Dealer")
        {
            pack = new Pack();      
        }
        public bool TakeCard(List<Player> players)
        {
            bool trigger = true;

            //players got their cards 
            for (int i = 0; i < players.Count; i++)
                if (!players[i].Pass)
                {
                    trigger = false;
                    players[i].AddCard(pack.PopCard());
                }

            return trigger;
        }
        public string GetCardName(int card)
        {
            return pack.numToCardname[card];
        }
        public string ChooseWinner(Player player1, Player player2)
        {
            int score1 = player1.Score;
            int score2 = player2.Score;

            // player1 won
            if (score1 <= 21 &&
                ((score1 == 21 && score2 != 21) ||
                (score1 < 21 && (score2 > 21
                                || (score2 < 21 && score1 > score2)))))
            {
                return player1.Name + " won";
            }

            // player2 won
            if (score2 <= 21 &&
               ((score2 == 21 && score1 != 21) ||
               (score2 < 21 && (score1 > 21
                               || (score1 < 21 && score2 > score1)))))
            {
                return player2.Name + " won";
            }

            // both won
            if (score1 == score2 && score1 <= 21)
                return "Both players won";
            if (score1 > 21 && score2 > 21)
                return "Both players lost";

            return "result is unknown";// not handled
        }
        public override void AddCard(int card)
        {
            base.AddCard(card);
            if (Score > 17)
                Pass = true;
        }


    }
}
