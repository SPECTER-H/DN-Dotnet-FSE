# EF Core Labs 4–6 — CRUD Operations

## Lab 4 — Inserting Initial Data

### Objective

Insert categories and products into the database using Entity Framework Core asynchronous methods.

### Concepts Covered

- `AddAsync()`
- `AddRangeAsync()`
- `SaveChangesAsync()`
- Navigation properties
- Asynchronous database operations

### Categories Added

- Electronics
- Groceries

### Products Added

- Laptop
- Rice Bag

### Example

```csharp
var electronics = new Category
{
    Name = "Electronics"
};

var groceries = new Category
{
    Name = "Groceries"
};

await context.Categories.AddRangeAsync(
    electronics,
    groceries);

var laptop = new Product
{
    Name = "Laptop",
    Price = 75000,
    Category = electronics
};

var riceBag = new Product
{
    Name = "Rice Bag",
    Price = 1200,
    Category = groceries
};

await context.Products.AddRangeAsync(
    laptop,
    riceBag);

await context.SaveChangesAsync();
```

---

## Lab 5 — Retrieving Data

### Objective

Retrieve product records using different Entity Framework Core query methods.

### Concepts Covered

- `ToListAsync()`
- `FindAsync()`
- `FirstOrDefaultAsync()`
- Conditional queries
- Asynchronous LINQ operations

### Retrieve All Products

```csharp
var products = await context.Products.ToListAsync();

foreach (var product in products)
{
    Console.WriteLine(
        $"{product.Name} - ₹{product.Price}");
}
```

### Find Product by ID

```csharp
var product = await context.Products.FindAsync(1);

Console.WriteLine($"Found: {product?.Name}");
```

### Find Product Using a Condition

```csharp
var expensiveProduct =
    await context.Products.FirstOrDefaultAsync(
        product => product.Price > 50000);

Console.WriteLine(
    $"Expensive product: {expensiveProduct?.Name}");
```

---

## Lab 6 — Updating and Deleting Records

### Objective

Update existing records and remove discontinued products from the database.

### Update a Product

The Laptop product was retrieved and its price was updated.

```csharp
var product = await context.Products
    .FirstOrDefaultAsync(
        product => product.Name == "Laptop");

if (product != null)
{
    product.Price = 70000;

    await context.SaveChangesAsync();
}
```

### Delete a Product

The Rice Bag product was retrieved and removed.

```csharp
var productToDelete = await context.Products
    .FirstOrDefaultAsync(
        product => product.Name == "Rice Bag");

if (productToDelete != null)
{
    context.Products.Remove(productToDelete);

    await context.SaveChangesAsync();
}
```

## Result

The project successfully demonstrated the following CRUD operations:

- Create
- Read
- Update
- Delete

All operations were performed using Entity Framework Core asynchronous methods.

## Run

```bash
dotnet run
```