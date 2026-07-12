# Lab 12 - DTOs and Circular References

## Objective

Prevent circular-reference problems when returning related entity data.

## Implemented

- Created a `ProductDTO`
- Projected Product and Category data using LINQ
- Serialized DTOs using `System.Text.Json`
- Used `[JsonIgnore]` as an alternative circular-reference solution
- Used `AsNoTracking()` for read-only queries

## DTO Projection

The entity data is projected into a simplified object containing:

- Product name
- Product price
- Category name

## Circular Reference Prevention

The `Products` navigation property in `Category` uses `[JsonIgnore]`.

This prevents recursive serialization between:

```text
Category -> Products -> Category -> Products
```

## Run

```bash
dotnet run
```

## Result

Product and category information was serialized successfully without circular-reference errors.