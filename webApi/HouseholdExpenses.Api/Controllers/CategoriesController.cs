using HouseholdExpenses.Api.Data;
using HouseholdExpenses.Api.Dtos;
using HouseholdExpenses.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HouseholdExpenses.Api.Controllers;
[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;
    public CategoriesController(AppDbContext context)
    {
        _context = context;
         }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        return await _context.Categories
            .AsNoTracking()
            .OrderBy(c => c.Description)
            .ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Category>> Create(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Description = dto.Description.Trim(),
            Purpose = dto.Purpose
        };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return Created($"/api/categories/{category.Id}", category);
    }
}