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
    }
}
