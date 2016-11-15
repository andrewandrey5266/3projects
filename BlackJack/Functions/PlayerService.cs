using System.Collections.Generic;
using BlackJack.Models;

namespace BlackJack.Functions
{
    class PlayerService : IGetCard
    {
        public  Player player { get; }

        public PlayerService (Player player)
        {
            this.player = player;
        }        

        public void AddCard(int value)
        {
            player.Score += value;
            player.Cards.Add(value);
        }
        public void Init()
        {
            if (player.Name != "Dealer")
                player.IsPassing = () => false;    
            player.Score = 0;
            player.Cards = new List<int>();
        }
    }
}
