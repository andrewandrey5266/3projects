using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Context
{
    class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<UnitCart> UnitCarts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired<Category>(s => s.category)
                .WithMany(s => s.Products);

            modelBuilder.Entity<UnitCart>()
                .HasRequired<Cart>(s => s.cart)
                .WithMany(s => s.UnitCarts);

            modelBuilder.Entity<UnitCart>()
                .HasRequired<Product>(s => s.product)
                .WithMany(s => s.UnitCarts);
        }
    }
}
