using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using troja.Data;
using troja.Models;

namespace troja.Controllers;


[ApiController]
[Route("[controller]")]
[EnableCors("MyAllowSpecificOrigins")]

public class CountryController : ControllerBase
{
    private readonly DataContext _context;

    public CountryController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<List<Country>>> AddCountry(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Country>>> GetAllTravels()
    {
        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpGet("{idcountry}")]
    public async Task<ActionResult<List<Country>>> GetTravel(int idcountry)
    {
        var country = await _context.Countries.FindAsync(idcountry);
        if (country == null)
        {
            return BadRequest("Country not found");
        }

        return Ok(country);
    }
}