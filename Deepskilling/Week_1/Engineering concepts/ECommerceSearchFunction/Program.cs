namespace ECommerceSearchFunction;
class Program
{
    static void Main(string[] args)
    {
        Product[] products =
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Phone", "Electronics"),
            new Product(103, "Shoes", "Fashion"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Book", "Education")
        };

        int searchId = 104;

        Console.WriteLine("Linear Search:");

        var linearResult =
            SearchOperations.LinearSearch(products, searchId);

        if (linearResult != null)
            Console.WriteLine(linearResult);
        else
            Console.WriteLine("Product not found");

        Console.WriteLine();

        Console.WriteLine("Binary Search:");

        var binaryResult =
            SearchOperations.BinarySearch(products, searchId);

        if (binaryResult != null)
            Console.WriteLine(binaryResult);
        else
            Console.WriteLine("Product not found");
    }
}