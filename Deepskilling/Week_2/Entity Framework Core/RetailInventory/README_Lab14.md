# Lab 14 - Batch Processing and Bulk Operations

## Objective

Compare normal Entity Framework Core updates with bulk updates for a large collection of products.

## Implemented

- Created 1,000 products for a regular update
- Created 1,000 products for a bulk update
- Updated stock using `SaveChangesAsync()`
- Updated stock using `BulkUpdateAsync()`
- Measured execution time using `Stopwatch`
- Verified that all records were updated

## Regular Update

The regular method tracks every entity and sends updates through `SaveChangesAsync()`.

## Bulk Update

The bulk method uses `EFCore.BulkExtensions` and executes the update through `BulkUpdateAsync()`.

## Run

```bash
dotnet run
```

## Result

Both methods updated 1,000 product records successfully, and their execution times were displayed for comparison.