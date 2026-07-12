using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.DTOs;

using var context = new AppDbContext();

Console.WriteLine("===== Lab 12 - DTOs and Circular References =====");

// DTO projection
var productDTOs = await context.Products
    .AsNoTracking()
    .Select(p => new ProductDTO
    {
        Name = p.Name,
        Price = p.Price,
        CategoryName = p.Category != null
            ? p.Category.Name
            : "Unknown"
    })
    .ToListAsync();

Console.WriteLine("\n=== Product DTOs ===");

foreach (var product in productDTOs)
{
    Console.WriteLine(
        $"{product.Name} | ₹{product.Price} | {product.CategoryName}");
}

// Serialize DTOs safely
var dtoJson = JsonSerializer.Serialize(
    productDTOs,
    new JsonSerializerOptions
    {
        WriteIndented = true
    });

Console.WriteLine("\n=== DTO JSON ===");
Console.WriteLine(dtoJson);

// Alternative: JsonIgnore on navigation property
var categories = await context.Categories
    .Include(c => c.Products)
    .AsNoTracking()
    .ToListAsync();

var categoryJson = JsonSerializer.Serialize(
    categories,
    new JsonSerializerOptions
    {
        WriteIndented = true
    });

Console.WriteLine("\n=== Categories JSON using JsonIgnore ===");
Console.WriteLine(categoryJson);