using RetailInventory.Data;

Console.WriteLine("Retail Inventory System");
Console.WriteLine("EF Core 8.0 Setup Complete");

using var context = new AppDbContext();

Console.WriteLine(
    $"Database Path: {Directory.GetCurrentDirectory()}");