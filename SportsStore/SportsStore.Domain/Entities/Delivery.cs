using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Delivery:IdEntity
    {
        public decimal DeliveryPrice { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public string Appartment { get; set; }
        public string PostIndex { get; set; }

        public Cart Cart { get; set; }
    }
}
