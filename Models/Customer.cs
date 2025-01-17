namespace EFCoreNews.Models;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Region { get; set; }
    public required Address CustomerAddress { get; set; }
}