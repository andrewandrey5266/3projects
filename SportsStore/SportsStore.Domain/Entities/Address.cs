using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class Address : IdEntity
    {
        public string Country { get; set; }
        public string City { get; set; }

        // Post office or local store
        public string LocalDepartment { get; set; }
    }
}
