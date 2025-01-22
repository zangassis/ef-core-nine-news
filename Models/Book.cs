namespace EFCoreNews.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string TenantId { get; set; } = null!;
    public Guid UserId { get; set; }
    public int SessionId { get; set; }
    public string PartitionKey { get; set; }
}
