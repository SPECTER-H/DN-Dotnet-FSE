using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

Console.WriteLine("===== Retail Inventory System =====");

//
// LAB 4 - INSERT DATA
//
if (!await context.Categories.AnyAsync())
{
    var electronics =
        new Category { Name = "Electronics" };

    var groceries =
        new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(
        electronics,
        groceries);

    var product1 =
        new Product
        {
            Name = "Laptop",
            Price = 75000,
            Category = electronics
        };

    var product2 =
        new Product
        {
            Name = "Rice Bag",
            Price = 1200,
            Category = groceries
        };

    await context.Products.AddRangeAsync(
        product1,
        product2);

    await context.SaveChangesAsync();

    Console.WriteLine("Initial data inserted.");
}

//
// LAB 5 - RETRIEVE DATA
//
Console.WriteLine();
Console.WriteLine("All Products:");

var products =
    await context.Products
        .Include(p => p.Category)
        .ToListAsync();

foreach (var p in products)
{
    Console.WriteLine(
        $"{p.Name} - ₹{p.Price} - {p.Category?.Name}");
}

Console.WriteLine();

var product =
    await context.Products.FindAsync(1);

Console.WriteLine(
    $"Found Product: {product?.Name}");

Console.WriteLine();

var expensive =
    await context.Products
        .FirstOrDefaultAsync(
            p => p.Price > 50000);

Console.WriteLine(
    $"Expensive Product: {expensive?.Name}");

//
// LAB 6 - UPDATE
//
var laptop =
    await context.Products
        .FirstOrDefaultAsync(
            p => p.Name == "Laptop");

if (laptop != null)
{
    laptop.Price = 70000;

    await context.SaveChangesAsync();

    Console.WriteLine(
        "Laptop price updated.");
}

//
// LAB 6 - DELETE
//
var riceBag =
    await context.Products
        .FirstOrDefaultAsync(
            p => p.Name == "Rice Bag");

if (riceBag != null)
{
    context.Products.Remove(riceBag);

    await context.SaveChangesAsync();

    Console.WriteLine(
        "Rice Bag deleted.");
}

Console.WriteLine();
Console.WriteLine("Final Product List:");

var finalProducts =
    await context.Products
        .Include(p => p.Category)
        .ToListAsync();

foreach (var p in finalProducts)
{
    Console.WriteLine(
        $"{p.Name} - ₹{p.Price}");
}