using System.Diagnostics;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

Console.WriteLine("===== Lab 14 - Bulk Operations =====");

// --------------------------------------------------
// Prepare two identical product lists for comparison
// --------------------------------------------------

List<int> regularProductIds;
List<int> bulkProductIds;

await using (var setupContext = new AppDbContext())
{
    var regularProducts = Enumerable.Range(1, 1000)
        .Select(index => new RetailInventory.Models.Product
        {
            Name = $"Regular Product {index}",
            Price = 100 + index,
            StockQuantity = 10,
            CategoryId = 1
        })
        .ToList();

    var bulkProducts = Enumerable.Range(1, 1000)
        .Select(index => new RetailInventory.Models.Product
        {
            Name = $"Bulk Product {index}",
            Price = 100 + index,
            StockQuantity = 10,
            CategoryId = 1
        })
        .ToList();

    setupContext.Products.AddRange(regularProducts);
    setupContext.Products.AddRange(bulkProducts);

    await setupContext.SaveChangesAsync();

    regularProductIds = regularProducts
        .Select(product => product.Id)
        .ToList();

    bulkProductIds = bulkProducts
        .Select(product => product.Id)
        .ToList();
}

// ------------------------------------------
// Regular update using SaveChangesAsync()
// ------------------------------------------

await using (var regularContext = new AppDbContext())
{
    var regularProducts = await regularContext.Products
        .Where(product => regularProductIds.Contains(product.Id))
        .ToListAsync();

    foreach (var product in regularProducts)
    {
        product.StockQuantity += 5;
    }

    var regularTimer = Stopwatch.StartNew();

    await regularContext.SaveChangesAsync();

    regularTimer.Stop();

    Console.WriteLine(
        $"Regular SaveChangesAsync: {regularTimer.ElapsedMilliseconds} ms");
}

// ------------------------------------------
// Bulk update using BulkUpdateAsync()
// ------------------------------------------

await using (var bulkContext = new AppDbContext())
{
    var bulkProducts = await bulkContext.Products
        .Where(product => bulkProductIds.Contains(product.Id))
        .ToListAsync();

    foreach (var product in bulkProducts)
    {
        product.StockQuantity += 5;
    }

    var bulkTimer = Stopwatch.StartNew();

    await bulkContext.BulkUpdateAsync(bulkProducts);

    bulkTimer.Stop();

    Console.WriteLine(
        $"BulkUpdateAsync: {bulkTimer.ElapsedMilliseconds} ms");
}

// -------------------------
// Verify updated stock data
// -------------------------

await using (var verificationContext = new AppDbContext())
{
    var regularUpdatedCount = await verificationContext.Products
        .CountAsync(product =>
            regularProductIds.Contains(product.Id) &&
            product.StockQuantity == 15);

    var bulkUpdatedCount = await verificationContext.Products
        .CountAsync(product =>
            bulkProductIds.Contains(product.Id) &&
            product.StockQuantity == 15);

    Console.WriteLine();
    Console.WriteLine($"Regular products updated: {regularUpdatedCount}");
    Console.WriteLine($"Bulk products updated: {bulkUpdatedCount}");
}