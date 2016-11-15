namespace BlackJack.Models
{
    class Dealer : Player
    {
        public Pack Pack { get; private set; }

        public Dealer(PackType packType) : base("Dealer")
        {
            Pack = new Pack(packType);
            IsPassing = () => Score > 17;       
        }
        
    }
}
