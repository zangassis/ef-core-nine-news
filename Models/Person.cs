using Microsoft.EntityFrameworkCore;

namespace EFCoreNews.Models;
public class Person
{
    public Person(HierarchyId pathFromPatriarch, string name)
    {
        PathFromPatriarch = pathFromPatriarch;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public HierarchyId PathFromPatriarch { get; set; }
}