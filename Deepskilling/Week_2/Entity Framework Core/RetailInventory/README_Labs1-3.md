# EF Core Labs 1–3 — ORM, DbContext and Migrations

## Lab 1 — Understanding ORM

### Objective

Understand Object-Relational Mapping and how Entity Framework Core connects C# objects with relational database tables.

### Concepts Covered

- Object-Relational Mapping
- Mapping C# classes to database tables
- Mapping class properties to table columns
- Database abstraction
- Productivity and maintainability
- EF Core versus Entity Framework

### Project Setup

A .NET console application named `RetailInventory` was created.

```bash
dotnet new console -n RetailInventory
cd RetailInventory
```

The required Entity Framework Core packages were installed.

The original hands-on exercise uses SQL Server. This implementation uses SQLite for compatibility with macOS while preserving the same EF Core concepts.

---

## Lab 2 — Setting Up Models and DbContext

### Objective

Create entity models and configure the Entity Framework Core database context.

### Models Created

- `Category`
- `Product`

### Category Model

The `Category` entity contains:

- `Id`
- `Name`
- A collection of products

### Product Model

The `Product` entity contains:

- `Id`
- `Name`
- `Price`
- `CategoryId`
- Category navigation property

### Relationship

A category can contain multiple products, while each product belongs to one category.

This represents a one-to-many relationship.

### Database Context

The `AppDbContext` class was created to manage the database connection and entity collections.

```csharp
public DbSet<Product> Products => Set<Product>();
public DbSet<Category> Categories => Set<Category>();
```

SQLite was configured as the database provider.

```csharp
optionsBuilder.UseSqlite("Data Source=retail.db");
```

---

## Lab 3 — Creating and Applying Migrations

### Objective

Use Entity Framework Core CLI commands to create and apply database migrations.

### Install EF Core CLI

```bash
dotnet tool install --global dotnet-ef
```

### Create Initial Migration

```bash
dotnet ef migrations add InitialCreate
```

The migration generated the database schema based on the entity models.

### Apply Migration

```bash
dotnet ef database update
```

### Result

The following were created successfully:

- `Categories` table
- `Products` table
- `Migrations` directory
- SQLite database file named `retail.db`

## Run

```bash
dotnet run
```