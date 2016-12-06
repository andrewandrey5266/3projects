using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Context
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        IQueryable<Category> Categories { get; }

        IQueryable<UnitCart> UnitCarts { get; }

        IQueryable<Cart> Carts { get; }
    }
}
