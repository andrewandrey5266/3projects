using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportsStore.Domain.Entities
{
    public class Cart : IdEntity
    {        
        public DateTime? OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public Delivery Delivery { get; set; }        
    }
}
