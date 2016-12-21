using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.ViewModel.Models
{
    public class ReviewViewModel
    {
        public string Comment { get; set; }
        public int Score { get; set; }
        public string DateTime { get; set; }


        public User User { get; set; }
        public Product Product { get; set; }
    }
}
