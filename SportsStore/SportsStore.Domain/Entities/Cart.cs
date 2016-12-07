using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public int UserID { get; set; }
        public int DeliveryID { get; set; }

        public ICollection<UnitCart> UnitCarts { get; set; }
        public Cart()
        {
            UnitCarts = new List<UnitCart>();
        }
    }
}
