namespace SportsStore.Domain.Entities
{
    public class Product : IdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public virtual Category Category { get; set; }

        public int DiscountID { get; set; }       // change later to Discount discount
    }
}
