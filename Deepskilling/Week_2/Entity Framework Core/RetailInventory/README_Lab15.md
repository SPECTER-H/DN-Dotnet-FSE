# Lab 15 - Optimistic Concurrency

## Objective

Detect conflicts when multiple users attempt to update the same database record simultaneously.

## Implemented

- Added a `RowVersion` byte-array property to `Product`
- Configured the property as a concurrency token
- Generated a new token whenever a product was added or modified
- Loaded the same product using two separate database contexts
- Saved the first update successfully
- Detected the outdated second update using `DbUpdateConcurrencyException`

## SQLite Adaptation

SQL Server provides a database-generated `rowversion` type.

SQLite does not provide an equivalent automatic row-version column, so this project uses an application-managed byte-array token. A new token is generated whenever a product is modified.

## Optimistic Concurrency

EF Core includes the original concurrency-token value in the update condition.

If another context has already changed the record, no matching row is updated and EF Core throws:

```text
DbUpdateConcurrencyException
```

## Run

```bash
dotnet run
```

## Result

The first employee's update succeeded, while the second employee's outdated update produced a concurrency conflict.