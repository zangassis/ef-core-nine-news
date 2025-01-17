namespace EFCoreNews.Models;
public class CustomerWithCount
{
    public Customer Customer { get; set; } = null!;
    public int TotalCount { get; set; }
}