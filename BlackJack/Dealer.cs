using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{   
    class Dealer : Player
    {
        public Pack Pack { get; private set; }
        
        public List<IGetCard> DistributeCards;
        

        public Dealer(PackType packType) : base("Dealer")
        {
            Pack = new Pack(packType);
            DistributeCards = new List<IGetCard>();

            //pass condition for dealer
            Init();
        }
        
        public bool HandOutCards()
        {
            bool trigger = true;

            foreach (var method in DistributeCards)
                if (((Player)method).IsPassing() == false)
                {
                    trigger = false;
                    method.AddCard(Pack.PopCard());
                }

            return trigger;                
        }
        public string ChooseWinner(List<Player> players)//list of players
        {
            var result = new StringBuilder("Score Table\n\n");
            foreach (var c in players)
            {
                result.Append(string.Format("Name: {0}, Score {1}, Cards = [", c.Name, c.Score));
                result.Append(string.Join(", ", c.Cards));
                result.Append(" ]\n\n");
            }
            return result.Append("the friendship has won\n").ToString();
        }

        public override void Init()
        {
            base.Init();           
            IsPassing = () => Score >= 17;
        }       


    }
}
