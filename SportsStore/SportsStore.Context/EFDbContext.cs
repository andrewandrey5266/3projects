using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Context
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<UnitCart> UnitCarts { get; set; }
               
        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<WishList> WishLists { get; set; }
    }
}
