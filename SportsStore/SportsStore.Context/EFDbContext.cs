using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }
    }
}
