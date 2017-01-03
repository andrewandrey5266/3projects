using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.ViewModel.Models
{
    public class WishListViewModel
    {
        public IEnumerable<WishList> Wishes { get; set; }


        public WishListViewModel() { }
        public WishListViewModel(IEnumerable<WishList> wishes)
        {
            this.Wishes = wishes;
        }
    }
}
