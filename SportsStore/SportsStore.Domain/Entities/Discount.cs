using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Discount : IdEntity
    {
        public int Percentage { get; set; }

        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
