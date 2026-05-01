using System.ComponentModel.DataAnnotations;
namespace HouseholdExpenses.Api.Models;
public class Person
{
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [Range(0, 130)]
    public int Age { get; set; }
    public List<Transaction> Transactions { get; set; } = new();
}