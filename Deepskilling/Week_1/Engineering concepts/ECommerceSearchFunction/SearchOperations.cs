namespace ECommerceSearchFunction;
public static class SearchOperations
{
    public static Product? LinearSearch(
        Product[] products,
        int productId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == productId)
            {
                return product;
            }
        }

        return null;
    }

    public static Product? BinarySearch(
        Product[] products,
        int productId)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (products[mid].ProductId == productId)
            {
                return products[mid];
            }

            if (products[mid].ProductId < productId)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return null;
    }
}