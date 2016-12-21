using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Review : IdEntity
    {
        public string Comment { get; set; }
        public int Score { get; set; }
        public string DateTime { get; set; }


        public User User { get; set; }
        public Product Product { get; set; }
    }
}
