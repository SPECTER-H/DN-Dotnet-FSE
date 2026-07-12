using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

Console.WriteLine("===== Lab 11 - Relationships =====");

// Add ProductDetail for Smartphone if it does not exist
var smartphone = await context.Products
    .Include(p => p.ProductDetail)
    .Include(p => p.Tags)
    .FirstAsync(p => p.Name == "Smartphone");

if (smartphone.ProductDetail == null)
{
    smartphone.ProductDetail = new ProductDetail
    {
        WarrantyInfo = "1 year manufacturer warranty"
    };
}

// Add tags if they do not exist
var onSaleTag = await context.Tags
    .FirstOrDefaultAsync(t => t.Name == "On Sale");

if (onSaleTag == null)
{
    onSaleTag = new Tag
    {
        Name = "On Sale"
    };

    context.Tags.Add(onSaleTag);
}

var newArrivalTag = await context.Tags
    .FirstOrDefaultAsync(t => t.Name == "New Arrival");

if (newArrivalTag == null)
{
    newArrivalTag = new Tag
    {
        Name = "New Arrival"
    };

    context.Tags.Add(newArrivalTag);
}

// Connect Product and Tags
if (!smartphone.Tags.Any(t => t.Name == "On Sale"))
{
    smartphone.Tags.Add(onSaleTag);
}

if (!smartphone.Tags.Any(t => t.Name == "New Arrival"))
{
    smartphone.Tags.Add(newArrivalTag);
}

await context.SaveChangesAsync();

// Reload with relationships
var productWithRelations = await context.Products
    .Include(p => p.ProductDetail)
    .Include(p => p.Tags)
    .FirstAsync(p => p.Name == "Smartphone");

Console.WriteLine($"Product: {productWithRelations.Name}");
Console.WriteLine($"Warranty: {productWithRelations.ProductDetail?.WarrantyInfo}");
Console.WriteLine("Tags:");

foreach (var tag in productWithRelations.Tags)
{
    Console.WriteLine($"- {tag.Name}");
}