namespace RetailInventory.Models;

public class Product
{
    public virtual ProductDetail? ProductDetail { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}