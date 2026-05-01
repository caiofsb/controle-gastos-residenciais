using System.ComponentModel.DataAnnotations;
namespace HouseholdExpenses.Api.Dtos;
public record CreatePersonDto(
    [Required, MaxLength(200)] string Name,
    [Range(0, 130)] int Age
);
public record UpdatePersonDto(
    [Required, MaxLength(200)] string Name,
    [Range(0, 130)] int Age
);