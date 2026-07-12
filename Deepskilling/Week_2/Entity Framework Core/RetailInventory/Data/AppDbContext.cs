using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();

    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlite("Data Source=retail.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-One Relationship
        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductDetail)
            .WithOne(pd => pd.Product)
            .HasForeignKey<ProductDetail>(pd => pd.ProductId);

        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics"
            },
            new Category
            {
                Id = 2,
                Name = "Groceries"
            });

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Smartphone",
                Price = 25000,
                StockQuantity = 50,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Wheat Flour",
                Price = 800,
                StockQuantity = 100,
                CategoryId = 2
            });
    }
}