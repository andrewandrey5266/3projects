using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Domain.Entities;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public class WishListService : IWishListService
    {
        EFDbContext context = new EFDbContext();
        public List<WishList> GetWishes(string id)
        {
            return context.WishLists
                .Include("User")
                .Include("Product")
                .Where(i => i.User.Id == id).ToList();
        }


        public bool AddWish(string productid, string userid)
        {
         
            if (context.WishLists.Where(i => i.Product.Id == productid && i.User.Id == userid).FirstOrDefault() == null)
            {
                context.WishLists.Add(
                     new WishList
                     {
                         User = context.Users.Where(i => i.Id == userid).First(),
                         Product = context.Products.Where(i => i.Id == productid).First()
                     });

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
