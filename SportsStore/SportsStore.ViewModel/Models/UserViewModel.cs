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
        private string name;
        private bool isAdmin;

        public string Id { get { return id; } }
        public string Name { get { return name; } }
        public bool IsAdmin { get { return isAdmin; } }

        public UserViewModel(string id, string name, bool isAdmin)
        {
            this.id = id;
            this.name = name;
            this.isAdmin = isAdmin;
        }

       
    }
}
