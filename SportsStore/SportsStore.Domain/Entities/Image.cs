using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Image :IdEntity
    {
        public string Source { get; set; }

        public virtual Product Product { get; set; }
    }
}
