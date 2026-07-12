namespace RetailInventory.DTOs;

public class ProductDTO
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}