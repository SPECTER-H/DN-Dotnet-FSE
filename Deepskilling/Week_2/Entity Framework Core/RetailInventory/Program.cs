using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

Console.WriteLine("===== Lab 15 - Optimistic Concurrency =====");

await using var firstEmployeeContext = new AppDbContext();
await using var secondEmployeeContext = new AppDbContext();

// Both employees read the same product before either saves.
var firstEmployeeProduct = await firstEmployeeContext.Products
    .FirstAsync(product => product.Name == "Smartphone");

var secondEmployeeProduct = await secondEmployeeContext.Products
    .FirstAsync(product => product.Name == "Smartphone");

Console.WriteLine(
    $"Initial stock: {firstEmployeeProduct.StockQuantity}");

// First employee updates and saves successfully.
firstEmployeeProduct.StockQuantity += 5;

await firstEmployeeContext.SaveChangesAsync();

Console.WriteLine(
    $"First employee saved stock: {firstEmployeeProduct.StockQuantity}");

// Second employee still has the old RowVersion.
secondEmployeeProduct.StockQuantity += 10;

try
{
    await secondEmployeeContext.SaveChangesAsync();

    Console.WriteLine(
        "Second employee update unexpectedly succeeded.");
}
catch (DbUpdateConcurrencyException)
{
    Console.WriteLine(
        "Concurrency conflict detected.");

    Console.WriteLine(
        "The second employee attempted to save outdated product data.");
}

// Read the actual database value.
await using var verificationContext = new AppDbContext();

var currentProduct = await verificationContext.Products
    .AsNoTracking()
    .FirstAsync(product => product.Name == "Smartphone");

Console.WriteLine(
    $"Final database stock: {currentProduct.StockQuantity}");