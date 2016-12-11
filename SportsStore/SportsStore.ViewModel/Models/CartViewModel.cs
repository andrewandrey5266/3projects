using SportsStore.Domain.Entities;
using System.Collections.Generic;
namespace SportsStore.ViewModel.Models
{
    public class CartViewModel
    {
        public Cart Cart;
        public string UserId;
        public string ProductId;// for product to be added
        public string ReturnUrl;
        public ICollection<UnitCart> UnitCarts;

        public void Clear()
        {
            
        }
    }
}