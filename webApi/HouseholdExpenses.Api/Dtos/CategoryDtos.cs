using System.ComponentModel.DataAnnotations;
using HouseholdExpenses.Api.Models;
namespace HouseholdExpenses.Api.Dtos;
public record CreateCategoryDto(
    [Required, MaxLength(400)] string Description,
    CategoryPurpose Purpose
);