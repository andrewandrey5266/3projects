using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public class CartService
    {
        public IProductRepository repository = new EFProductRepository();

        public void AddCartToDB(Cart cart)
        {
            ((EFProductRepository)repository).SaveCart(cart);
        }
        public void AddItem(Cart cart,Product product, int quantity)
        {
            if (cart.UnitCarts
                .Where(i => i.product.ProductID == product.ProductID)
                .Select(x => x).Count() != 0)
            {
                cart.UnitCarts.Where(i => i.product == product)
                    .ToList()
                    .ForEach(i => i.Quantity = i.Quantity + 1);
                return;
            }
            UnitCart unitCart = new UnitCart
            {
                ProductID = product.ProductID,
                CartID = cart.CartID,
                Quantity = quantity,
                cart = cart,
                product = product
                /*cart = new Cart
                {
                    CartID = cart.CartID,
                    OrderDate = cart.OrderDate,
                    TotalPrice = cart.TotalPrice,
                    UserID = cart.UserID,
                    DeliveryID = cart.DeliveryID
                },
                product = new Product
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryID = product.CategoryID,
                    DiscountID = product.DiscountID
                }*/
            };

            cart.UnitCarts.Add(unitCart);
            /*cart.UnitCarts.Add(new UnitCart
            {
                ProductID = unitCart.ProductID,
                CartID = unitCart.CartID,
                Quantity = unitCart.Quantity,
                cart = unitCart.cart,
                product = unitCart.product,
            });*/

            //add to product
            repository.Products
                .Where(i => i.ProductID == product.ProductID)
                .ToList()
                .ForEach(i => i.UnitCarts.Add(unitCart));

            //((EFProductRepository)repository).SaveUnitCart(unitCart);
        }
        public void RemoveLine(Cart cart, Product product)
        {
            ((List<UnitCart>)cart.UnitCarts).RemoveAll(c => c.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue(Cart cart)
        {
            return cart.UnitCarts.Sum(i => i.product.Price * i.Quantity);

            //i.product.Price * i.Quantity
        }
    }
}
