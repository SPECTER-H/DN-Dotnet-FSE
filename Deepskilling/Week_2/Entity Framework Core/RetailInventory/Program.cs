using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

Console.WriteLine("===== Lab 10 - Loading Strategies =====");

//
// EAGER LOADING
//
Console.WriteLine("\n=== Eager Loading ===");

var eagerProducts = await context.Products
    .Include(p => p.Category)
    .ToListAsync();

foreach (var product in eagerProducts)
{
    Console.WriteLine($"{product.Name} -> {product.Category?.Name}");
}

//
// EXPLICIT LOADING
//
Console.WriteLine("\n=== Explicit Loading ===");

var firstProduct = await context.Products.FirstAsync();

await context.Entry(firstProduct)
    .Reference(p => p.Category)
    .LoadAsync();

Console.WriteLine($"{firstProduct.Name} -> {firstProduct.Category?.Name}");

//
// LAZY LOADING
//
Console.WriteLine("\n=== Lazy Loading ===");

var lazyProduct = await context.Products.FirstAsync();

Console.WriteLine($"{lazyProduct.Name} -> {lazyProduct.Category?.Name}");