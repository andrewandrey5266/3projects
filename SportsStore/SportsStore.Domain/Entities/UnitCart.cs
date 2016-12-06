using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Domain.Entities
{
    public class UnitCart
    {
        [Column(Order = 0), ForeignKey("product"), Key]
        public int ProductID { get; set; }

        [Column(Order = 1), ForeignKey("cart"), Key]
        public int CartID { get; set; }

        public int Quantity { get; set; }
        
        public Product product { get; set; }
        public Cart cart { get; set; }       
    }
}
