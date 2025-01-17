using EFCoreNews.Data;
using EFCoreNews.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace EFCoreNews.Services;
public class EFNewsService
{
    private readonly NewsDbContext _dbContext;

    public EFNewsService(NewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ComplexTypesGroupByAsync()
    {
        var groupedAddresses = await _dbContext.Customers
            .GroupBy(b => b.CustomerAddress)
            .Select(g => new { g.Key, Count = g.Count() })
            .ToListAsync();

        groupedAddresses.ForEach(g =>
        {
            Console.WriteLine($"Key: {g.Key} - Group: {g.Count}");
        });
    }

    public async Task ExecuteUpdateAddress(Address newAddress)
    {
        await _dbContext.Customers
            .Where(e => e.Region == "USA")
            .ExecuteUpdateAsync(s => s.SetProperty(b => b.CustomerAddress, newAddress));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CustomerWithCount>> GetUSCustomers()
    {
        var usCustomers = _dbContext.Customers.Where(c => c.Region.Contains("USA"));

        return await usCustomers
            .Where(c => c.Id > 1)
            .Select(c => new CustomerWithCount { Customer = c, TotalCount = usCustomers.Count() })
            .Skip(2).Take(10)
            .ToArrayAsync();
    }

    public async Task ProcessReadOnlyPrimitiveCollections()
    {
        var today = DateTime.Today;

        var pastEvents = await _dbContext.PartyEvents
            .Where(e => e.CreatedDate < today)
            .Select(p => new
            {
                Id = Guid.NewGuid(),
                Name = p.Name,
                Count = p.EventDays.Count(d => p.EventDays.Contains(d)),
                TotalCount = p.EventDays.Count
            })
            .ToListAsync();

        var initialList = new List<int> { 1, 2, 3 };

        var readWriteCollection = new List<int>(initialList);
        var readOnlyCollection = new ReadOnlyCollection<int>(initialList);

        readWriteCollection.Add(4);

        //This generates an error
        //readOnlyCollection.Add(4);
    }

    public async Task<List<Post>> GetPostsWithAuthors()
    {
        var postsWithAuthors = await _dbContext.Posts.Where(p => p.Authors.Any()).ToListAsync();
        return postsWithAuthors ?? new List<Post>();
    }

    public async Task<int> GetRecentPostQuantity()
    {
        int recentPostQuantity = await _dbContext.Posts
            .Where(p => p.CreatedDate >= DateTime.UtcNow)
            .Take(6)
            .CountAsync();

        return recentPostQuantity;
    }

    public async Task<List<Post>> GetPostsWithAuthorsUsingCount()
    {
        var postsWithAuthors = await _dbContext.Posts
            .Where(b => b.Authors.Count > 0)
            .ToListAsync();
        return postsWithAuthors;
    }

    public void SeedCustomerData()
    {
        if (!_dbContext.Customers.Any())
        {
            _dbContext.Customers.AddRange(
                new Customer
                {
                    Name = "John Doe",
                    Phone = "555-1234",
                    Region = "USA",
                    CustomerAddress = new Address("123 Main St", 123, "New York", "USA", "10001")
                },
                new Customer
                {
                    Name = "Jane Smith",
                    Phone = "555-5678",
                    Region = "USA",
                    CustomerAddress = new Address("456 Elm St", 456, "Los Angeles", "USA", "90001")
                },
                new Customer
                {
                    Name = "Mike Johnson",
                    Phone = "555-7890",
                    Region = "USA",
                    CustomerAddress = new Address("789 Oak Ave", 789, "Chicago", "USA", "60601")
                }
                ,
                new Customer
                {
                    Name = "Maria Johnson",
                    Phone = "555-3311",
                    Region = "USA",
                    CustomerAddress = new Address("789 Oak Ave", 789, "Chicago", "USA", "60601")
                }
            );
            _dbContext.SaveChanges();
        }
    }
}
