using InventoryManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Id", schema: "shared")
                .StartsAt(100004)
                .IncrementsBy(1)
                .HasMax(999999);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEXT VALUE FOR shared.Id");

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                SeedData_Products()
            );

            base.OnModelCreating(modelBuilder);
        }

        private Product[] SeedData_Products() => new Product[] {
                new Product
                {
                    Id = 100000,
                    Name = "Laptop",
                    Description = "16GB RAM, 512GB SSD",
                    Price = 89999.99m,
                    StockAvailable = 10,
                    Category = "Electronics",
                    CreatedAt = DateTime.UtcNow.AddDays(-15)
                },
                new Product
                {
                    Id = 100001,
                    Name = "Smartphone",
                    Description = "5G-enabled device",
                    Price = 49999.50m,
                    StockAvailable = 25,
                    Category = "Electronics",
                    CreatedAt = DateTime.UtcNow.AddDays(-12)
                },
                new Product
                {
                    Id = 100002,
                    Name = "Notebook",
                    Description = "200 pages, ruled",
                    Price = 59.99m,
                    StockAvailable = 500,
                    Category = "Stationery",
                    CreatedAt = DateTime.UtcNow.AddDays(-10)
                },
                new Product
                {
                    Id = 100003,
                    Name = "Table Fan",
                    Description = "3-speed oscillation",
                    Price = 1299.99m,
                    StockAvailable = 100,
                    Category = "Appliances",
                    CreatedAt = DateTime.UtcNow.AddDays(-21)
                }
        };
    }
}
