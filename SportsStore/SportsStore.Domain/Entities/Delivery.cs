using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Delivery:IdEntity
    {
        public decimal Price { get; set; }
        
        public Address Address { get; set; }
    }
}
