using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Models;

namespace BlackJack.Functions
{
    class DealerService : IGetCard, IComparer<Player>
    {
        public Dealer dealer { get; }

        private PackService packService;
        private PlayerService playerService;

        public DealerService(Dealer dealer, PlayerService playerService)
        {
            this.dealer = dealer;

            packService = new PackService(dealer.Pack);
            this.playerService = playerService;
        }
        public bool HandOutCards()
        {
            bool trigger = true;

            if (playerService.player.IsPassing == false)
            {
                trigger = false;
                playerService.AddCard(packService.PopCard());
            }
            this.dealer.IsPassing = this.dealer.Score > 17;
            if (this.dealer.IsPassing == false)
            {
                trigger = false;
                this.AddCard(packService.PopCard());
            }

            return trigger;
        }
        public string ChooseWinner(List<Player> players)//list of players
        {
            try
            {
                players.Sort(this);               
            }
            catch (InvalidOperationException ioe)
            {
                Console.Write(ioe.InnerException.Message);
            }
            
            var result = new StringBuilder("Score Table\n\n");
            foreach (var c in players)
            {
                result.Append(string.Format("Name: {0} Cards = [", c.Name));
                result.Append(string.Join(", ", c.Cards));
                result.Append(string.Format(" ] = {0}\n\n", c.Score));
            }
            return result.ToString();
        }

        public void AddCard(int value)
        {
            dealer.Score += value;
            dealer.Cards.Add(value);
        }
        public void InitAll()
        {
            playerService.Init();
            this.Init();
            this.packService.ChangePack();
        }
        private void Init()
        {
            dealer.Score = 0;
            dealer.Cards = new List<int>();
            
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
