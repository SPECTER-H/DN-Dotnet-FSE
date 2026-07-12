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
        // One-to-one relationship
        modelBuilder.Entity<Product>()
            .HasOne(product => product.ProductDetail)
            .WithOne(productDetail => productDetail.Product)
            .HasForeignKey<ProductDetail>(
                productDetail => productDetail.ProductId);

        // Application-managed optimistic-concurrency token
        modelBuilder.Entity<Product>()
            .Property(product => product.RowVersion)
            .IsConcurrencyToken();

        // Seed categories
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

        // Seed products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Smartphone",
                Price = 25000,
                StockQuantity = 50,
                CategoryId = 1,
                RowVersion = new byte[] { 1 }
            },
            new Product
            {
                Id = 2,
                Name = "Wheat Flour",
                Price = 800,
                StockQuantity = 100,
                CategoryId = 2,
                RowVersion = new byte[] { 1 }
            });
    }

    public override int SaveChanges()
    {
        UpdateRowVersions();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        UpdateRowVersions();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateRowVersions()
    {
        var modifiedProducts = ChangeTracker
            .Entries<Product>()
            .Where(entry =>
                entry.State == EntityState.Added ||
                entry.State == EntityState.Modified);

        foreach (var entry in modifiedProducts)
        {
            entry.Entity.RowVersion = Guid.NewGuid().ToByteArray();
        }
    }
}