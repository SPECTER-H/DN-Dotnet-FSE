# Lab 11 - Entity Relationships

## Objective

Configure one-to-one and many-to-many relationships using Entity Framework Core.

## Relationships Implemented

### One-to-One

- `Product`
- `ProductDetail`

A product can have one product detail record containing warranty information.

### Many-to-Many

- `Product`
- `Tag`

A product can have multiple tags, and a tag can belong to multiple products.

## Concepts Covered

- Navigation properties
- Fluent API
- `HasOne()`
- `WithOne()`
- `HasForeignKey()`
- Automatic many-to-many join tables
- Eager loading with `Include()`

## Run

```bash
dotnet run
```

## Result

The Smartphone product is linked to:

- One warranty detail
- On Sale tag
- New Arrival tag