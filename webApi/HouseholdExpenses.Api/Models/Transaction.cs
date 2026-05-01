using System.ComponentModel.DataAnnotations;
namespace HouseholdExpenses.Api.Models;
public class Transaction
{
    public int Id { get; set; }
    [Required]
    [MaxLength(400)]
    public string Description { get; set; } = string.Empty;
    [Range(0.01, double.MaxValue)]
    public decimal Value { get; set; }
    public TransactionType Type { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}