using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using troja.Data;
using troja.Models;

namespace troja.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("MyAllowSpecificOrigins")]

public class TravelController : ControllerBase
{
    private readonly DataContext _context;

    public TravelController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<List<Travel>>> AddTravel(Travel travel)
    {
        _context.Travels.Add(travel);
        await _context.SaveChangesAsync();
        
        return Ok(await _context.Travels.ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Travel>>> GetAllTravels()
    {
        return Ok(await _context.Travels.ToListAsync());
    }

    [HttpGet("{IdTravel}")]
    public async Task<ActionResult<List<Travel>>> GetTravel(int idtravel)
    {
        var travel = await _context.Travels.FindAsync(idtravel);
        if (travel == null)
        {
            return BadRequest("Travel not found");
        }
        return Ok(travel);
    }
    
    [HttpGet("/Travel/Count")]
    public int Count()
    {
        var count = _context.Travels.Count();
        return count;

    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAllTravels()
    {
        var travels = await _context.Travels.ToListAsync();
        _context.Travels.RemoveRange(travels);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

