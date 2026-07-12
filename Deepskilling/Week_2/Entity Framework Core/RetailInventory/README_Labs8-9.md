# EF Core Labs 8–9 — Schema Changes and Data Seeding

## Lab 8 — Managing Schema Changes

### Objective

Modify the database schema using Entity Framework Core migrations.

### Schema Change

A new property named `StockQuantity` was added to the `Product` model.

```csharp
public int StockQuantity { get; set; }
```

This property stores the available inventory quantity for each product.

### Create Migration

```bash
dotnet ef migrations add AddStockQuantity
```

### Apply Migration

```bash
dotnet ef database update
```

### Result

The `Products` table was updated with a new `StockQuantity` column.

---

## Lab 9 — Seeding Initial Data

### Objective

Automatically insert predefined categories and products when the database is created or updated through migrations.

### Seeded Categories

- Electronics
- Groceries

### Seeded Products

| Product | Price | Stock | Category |
|---|---:|---:|---|
| Smartphone | ₹25,000 | 50 | Electronics |
| Wheat Flour | ₹800 | 100 | Groceries |

### Category Seed Configuration

```csharp
modelBuilder.Entity<Category>().HasData(
    new Category
    {
        Id = 1,
        Name = "Electronics"
    },
    new Category
    {
        Id = 2,
        Name = "Groceries"
    });
```

### Product Seed Configuration

```csharp
modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Name = "Smartphone",
        Price = 25000,
        StockQuantity = 50,
        CategoryId = 1
    },
    new Product
    {
        Id = 2,
        Name = "Wheat Flour",
        Price = 800,
        StockQuantity = 100,
        CategoryId = 2
    });
```

### Migration Commands

```bash
dotnet ef migrations add SeedInitialData
dotnet ef database update
```

## Result

The SQLite database was successfully populated with initial category and product records through Entity Framework Core data seeding.

## Run

```bash
dotnet run
```