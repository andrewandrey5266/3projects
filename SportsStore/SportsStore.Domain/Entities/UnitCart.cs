namespace SportsStore.Domain.Entities
{
    public class UnitCart:IdEntity
    {        
        public int Quantity { get; set; }
        
        public Product Product { get; set; }
        public Cart Cart { get; set; }       
    }
}
