using EFCoreNews.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreNews.Data;
public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PartyEvent> PartyEvents => Set<PartyEvent>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSeeding((context, _) =>
        {
            var testPerson = context.Set<Person>().FirstOrDefault(p => p.Name == "Test_Person");
            if (testPerson == null)
            {
                context.Set<Person>().Add(new Person(HierarchyId.Parse("/1/"), "Test_Person"));
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var testPerson = await context.Set<Person>().FirstOrDefaultAsync(p => p.Name == "Test_Person", cancellationToken);
            if (testPerson == null)
            {
                context.Set<Person>().Add(new Person(HierarchyId.Parse("/1/"), "Test_Person"));
                await context.SaveChangesAsync(cancellationToken);
            }
        });
}