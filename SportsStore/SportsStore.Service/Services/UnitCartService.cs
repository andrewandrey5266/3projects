using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Interfaces;
using System.Data.Linq;
namespace SportsStore.Service.Services 
{
    public class UnitCartService : IUnitCartService
    {
        public EFDbContext context;

        public UnitCartService()
        {
            this.context = new EFDbContext();
        }

        public void AddItem(CartViewModel cartVM)
        {
            if (FindUnitCarts(cartVM) > 0)
            {
                SelectUnitCarts(cartVM)
                    .Where(i => i.Product.Id == cartVM.ProductId)
                    .ToList()
                    .ForEach(i => i.Quantity = i.Quantity + 1);
                context.SaveChanges();
                return;
            }

            
            context.UnitCarts.Add(new UnitCart
            {
                Cart = context.Carts.Where(i=> i.Id ==cartVM.Cart.Id).First(),
                Quantity = 1,
                Product = context.Products.Where(i => i.Id == cartVM.ProductId).First()
            });

            context.SaveChanges();
        }

        public void RemoveItem(CartViewModel cartVM)
        {
            context.UnitCarts.RemoveRange
                (
                context.UnitCarts
                .Include("Product")
                .Where(i => i.Cart.Id == cartVM.Cart.Id && i.Product.Id == cartVM.ProductId)
                );
            context.SaveChanges();
        }

        public List<UnitCart> SelectUnitCarts(CartViewModel cartProductVM)
        {
            return context.UnitCarts
                .Include("Product")
                .Include("Cart")
                .Where(i => i.Cart.Id == cartProductVM.Cart.Id).ToList();
            //     && i.Product.Id == cartProductVM.ProductId).ToList();
            //return context.UnitCarts.Where(i => i.Cart.Id == cartProductVM.Cart.Id
            //     && i.Product.Id == cartProductVM.ProductId).ToList();
        }
        public int FindUnitCarts(CartViewModel cartVM)
        {
            return context.UnitCarts
                .Include("Product")
                .Where(i => i.Cart.Id == cartVM.Cart.Id && i.Product.Id == cartVM.ProductId)
                .Count();
        }
             
    }
}
