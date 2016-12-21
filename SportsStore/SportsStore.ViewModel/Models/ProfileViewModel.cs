using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SportsStore.ViewModel.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Logname { get; set; }

        public bool IsAdmin { get; set; }
    }
}
