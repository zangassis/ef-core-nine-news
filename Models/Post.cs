namespace EFCoreNews.Models;
public class Post
{
    public Guid Id { get; set; } 
    public string Title { get; set; }
    public string Body { get; set; }
    public List<Author> Authors { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
