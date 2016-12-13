using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public class Product : IdEntity
    {
        [Required(ErrorMessage="Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a disctiption")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a price")]    
        [Range(0.01, 999.00, ErrorMessage = "Please enter a positive price in range of [0.01, 999.00]")]
        public decimal Price { get; set; }
        
        [Required]
        public virtual Category Category { get; set; }

        [Range(0, 100)]
        public int DiscountID { get; set; }       // change later to Discount discount
    }
}
