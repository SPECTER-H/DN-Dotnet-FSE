# EF Core Lab 7 — LINQ Queries

## Objective

Use LINQ with Entity Framework Core to filter, sort, count and project product data.

## Concepts Covered

- `Where()`
- `OrderByDescending()`
- `Select()`
- `FirstOrDefaultAsync()`
- `CountAsync()`
- `Include()`
- LINQ projections

## Filtering Products

Products with prices greater than ₹1,000 were retrieved using `Where()`.

```csharp
var filteredProducts = await context.Products
    .Where(product => product.Price > 1000)
    .ToListAsync();
```

## Sorting Products

The filtered products were sorted by price in descending order.

```csharp
var sortedProducts = await context.Products
    .Where(product => product.Price > 1000)
    .OrderByDescending(product => product.Price)
    .ToListAsync();
```

## Projecting Selected Fields

LINQ projection was used to retrieve only the required product fields.

```csharp
var productDTOs = await context.Products
    .Select(product => new
    {
        product.Name,
        product.Price
    })
    .ToListAsync();
```

## Retrieving the First Matching Product

```csharp
var firstProduct = await context.Products
    .FirstOrDefaultAsync(
        product => product.Price > 1000);
```

## Counting Products

```csharp
var productCount = await context.Products.CountAsync();
```

## Loading Related Category Data

```csharp
var productsWithCategories = await context.Products
    .Include(product => product.Category)
    .ToListAsync();
```

## Result

The project successfully demonstrated:

- Filtering product records
- Sorting products by price
- Counting records
- Retrieving the first matching record
- Projecting selected fields
- Loading related category information

## Run

```bash
dotnet run
```