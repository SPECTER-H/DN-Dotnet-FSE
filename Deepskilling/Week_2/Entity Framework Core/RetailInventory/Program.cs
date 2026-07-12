using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

Console.WriteLine("===== Lab 7 - LINQ Queries =====");

// 1. Where
var expensiveProducts = await context.Products
    .Where(p => p.Price > 1000)
    .ToListAsync();

Console.WriteLine("\nProducts costing more than ₹1000:");

foreach (var product in expensiveProducts)
{
    Console.WriteLine($"{product.Name} - ₹{product.Price}");
}

// 2. OrderByDescending
var orderedProducts = await context.Products
    .OrderByDescending(p => p.Price)
    .ToListAsync();

Console.WriteLine("\nProducts sorted by price:");

foreach (var product in orderedProducts)
{
    Console.WriteLine($"{product.Name} - ₹{product.Price}");
}

// 3. FirstOrDefault
var firstProduct = await context.Products
    .FirstOrDefaultAsync();

Console.WriteLine($"\nFirst Product: {firstProduct?.Name}");

// 4. Count
var totalProducts = await context.Products.CountAsync();

Console.WriteLine($"Total Products: {totalProducts}");

// 5. Include
var productsWithCategory = await context.Products
    .Include(p => p.Category)
    .ToListAsync();

Console.WriteLine("\nProducts with Category:");

foreach (var product in productsWithCategory)
{
    Console.WriteLine($"{product.Name} ({product.Category?.Name})");
}