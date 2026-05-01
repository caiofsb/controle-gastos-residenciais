using System.ComponentModel.DataAnnotations;
namespace HouseholdExpenses.Api.Models;
public class Category
{
    public int Id { get; set; }
    [Required]
    [MaxLength(400)]
    public string Description { get; set; } = string.Empty;
    public CategoryPurpose Purpose { get; set; }
    public List<Transaction> Transactions { get; set; } = new();
}