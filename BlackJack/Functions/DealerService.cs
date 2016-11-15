using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Models;

namespace BlackJack.Functions
{
    class DealerService :  IComparer<Player>
    {
        public Dealer dealer { get; }

        private PackService packService;       
        List<PlayerService> playersServices = new List<PlayerService>();

        public DealerService(Dealer dealer, params Player [] players)
        {
            this.dealer = dealer;
            
            //initialize PackService
            packService = new PackService(dealer.Pack);

            //initialize PlayerService List
            this.playersServices.Add(new PlayerService(dealer));
            foreach (var p in players)
                playersServices.Add(new PlayerService(p));            
        }

        public bool HandOutCards()
        {
            bool trigger = true;
            
            foreach (var c in playersServices)
            {
                if (c.player.IsPassing() == false)
                {
                    trigger = false;
                    c.AddCard(packService.PopCard());
                }
            }

            return trigger;
        }
        public string GetRateList(List<Player> players)//list of players
        {
            players.Sort(this);               
                        
            var result = new StringBuilder("Score Table\n\n");
            foreach (var c in players)
            {
                result.Append(string.Format("Name: {0} Cards = [", c.Name));
                result.Append(string.Join(", ", c.Cards));
                result.Append(string.Format(" ] = {0}\n\n", c.Score));
            }
            return result.ToString();
        }              
        public void InitAll()
        {
            foreach (var c in playersServices)
                c.Init();           
            this.packService.ChangePack();
        }       
        public int Compare(Player player1, Player player2)
        {            
            int score1 = player1.Score;
            int score2 = player2.Score;

            if (score1 == 21 && score2 != 21)
                return -1;
            if (score1 != 21 && score2 == 21)
                return 1;

            if (score1 < 21 && score2 < 21)
                return -score1.CompareTo(score2);

            if (score1 > 21 && score2 > 21)
                return score1.CompareTo(score2);

            return score1.CompareTo(score2);

        }
    }
}
