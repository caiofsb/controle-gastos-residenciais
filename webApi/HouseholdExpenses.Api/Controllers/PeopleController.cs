using HouseholdExpenses.Api.Data;
using HouseholdExpenses.Api.Dtos;
using HouseholdExpenses.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HouseholdExpenses.Api.Controllers;
[ApiController]
[Route("api/people")]
public class PeopleController : ControllerBase
{
    private readonly AppDbContext _context;
    public PeopleController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
         return await _context.People
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync();
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Person>> GetById(int id)
    {
        var person = await _context.People.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return person is null ? NotFound("Pessoa não encontrada.") : Ok(person);
    }
    [HttpPost]
    public async Task<ActionResult<Person>> Create(CreatePersonDto dto)
    {
        var person = new Person
        {
            Name = dto.Name.Trim(),
            Age = dto.Age
        };
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdatePersonDto dto)
    {
        var person = await _context.People.FindAsync(id);
        if (person is null) return NotFound("Pessoa não encontrada.");
        person.Name = dto.Name.Trim();
        person.Age = dto.Age;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _context.People.FindAsync(id);
        if (person is null) return NotFound("Pessoa não encontrada.");
        _context.People.Remove(person);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}