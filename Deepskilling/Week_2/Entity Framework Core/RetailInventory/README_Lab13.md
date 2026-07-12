# Lab 13 - Query Caching and Tracking Behavior

## Objective

Improve the performance of frequent read-only database queries using Entity Framework Core.

## Implemented

- Read-only queries using `AsNoTracking()`
- Entity tracking verification using `ChangeTracker`
- A compiled asynchronous query using `EF.CompileAsyncQuery()`
- Filtering products based on a minimum price

## AsNoTracking

`AsNoTracking()` prevents EF Core from storing retrieved entities in the change tracker.

This is useful when:

- Data is only being displayed
- No updates are required
- Query performance is important

## Compiled Query

The compiled query retrieves products whose prices are greater than a supplied minimum value.

Compiled queries reduce repeated query-compilation overhead when the same query is executed frequently.

## Run

```bash
dotnet run
```

## Result

The read-only query returned products without tracking entities, and the compiled query successfully returned products above the specified price.