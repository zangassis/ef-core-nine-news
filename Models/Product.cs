namespace EFCoreNews.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
    public decimal PriceTotal { get; set; } = decimal.Zero;
}