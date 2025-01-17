using System.Collections.ObjectModel;

namespace EFCoreNews.Models;
public class PartyEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ReadOnlyCollection<int> EventDays { get; set; }
    public DateTime CreatedDate { get; set; }
}