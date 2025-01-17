using EFCoreNews.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreNews.Data;
public class NewsDbContext: DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PartyEvent> PartyEvents => Set<PartyEvent>();
    public DbSet<Post> Posts => Set<Post>();
}