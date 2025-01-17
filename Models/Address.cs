using System.ComponentModel.DataAnnotations.Schema;
namespace EFCoreNews.Models;
[ComplexType]
public record class Address(string Street, int Number, string City, string Country, string PostCode);