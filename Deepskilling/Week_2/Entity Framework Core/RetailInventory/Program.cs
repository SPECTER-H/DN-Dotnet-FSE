using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Queries;

await using var context = new AppDbContext();

Console.WriteLine("===== Lab 13 - Tracking and Compiled Queries =====");

// AsNoTracking demonstration
Console.WriteLine("\n=== Read-Only Query with AsNoTracking ===");

var readOnlyProducts = await context.Products
    .AsNoTracking()
    .OrderBy(product => product.Name)
    .ToListAsync();

foreach (var product in readOnlyProducts)
{
    Console.WriteLine(
        $"{product.Name} | Price: ₹{product.Price} | Stock: {product.StockQuantity}");
}

Console.WriteLine(
    $"\nTracked entities after AsNoTracking query: " +
    $"{context.ChangeTracker.Entries().Count()}");

// Compiled query demonstration
const decimal minimumPrice = 1000;

Console.WriteLine(
    $"\n=== Compiled Query: Products Above ₹{minimumPrice} ===");

await foreach (
    var product in ProductQueries.ExpensiveProducts(context, minimumPrice))
{
    Console.WriteLine($"{product.Name} | ₹{product.Price}");
}