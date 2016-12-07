using System.Linq;
using SportsStore.Domain.Entities;
namespace SportsStore.Context
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
        
        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }
        
        public IQueryable<UnitCart> UnitCarts
        {
            get { return context.UnitCarts; }
        }

        public IQueryable<Cart> Carts
        {
            get { return context.Carts; }
        }

        public void SaveCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }
        public void SaveUnitCart(UnitCart unitCart)
        {
            if (context.UnitCarts
                .Where(i => i.CartID == unitCart.CartID && i.ProductID == unitCart.ProductID)
                .Select(x=>x)
                .Count() == 0)
            context.UnitCarts.Add(unitCart);
            context.SaveChanges();
        }
    }
}
