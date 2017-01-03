using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SportsStore.ViewModel.Models
{
    public class UserViewModel
    {
        private string id; 
        private bool isAdmin;

        public string Id { get { return id; } }
        public bool IsAdmin { get { return isAdmin; } }


        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public WishListViewModel wishes { get; set; }

        public UserViewModel(string id, bool isAdmin)
        {
            this.id = id;         
            this.isAdmin = isAdmin;
        }

       
    }
}
