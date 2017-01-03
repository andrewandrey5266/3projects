using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Entities
{
    public class WishList : IdEntity
    {
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
