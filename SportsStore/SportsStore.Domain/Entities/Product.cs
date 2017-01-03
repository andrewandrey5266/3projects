using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public class Product : IdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        public virtual Category Category { get; set; }   
        public virtual Discount Discount { get; set; }     
      
    }
}
