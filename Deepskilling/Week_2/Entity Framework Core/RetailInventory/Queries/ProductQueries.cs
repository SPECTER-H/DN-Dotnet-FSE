using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory.Queries;

public static class ProductQueries
{
    public static readonly Func<
        AppDbContext,
        decimal,
        IAsyncEnumerable<Product>> ExpensiveProducts =
            EF.CompileAsyncQuery(
                (AppDbContext context, decimal minimumPrice) =>
                    context.Products
                        .AsNoTracking()
                        .Where(product => product.Price > minimumPrice)
                        .OrderByDescending(product => product.Price)
                        .Select(product => product));
}