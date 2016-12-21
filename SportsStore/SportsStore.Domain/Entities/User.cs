using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class User :IdEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Logname { get; set; }

        public bool IsAdmin { get; set; }
    }
}
