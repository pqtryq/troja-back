using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using troja.Data;
using troja.Models;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;


namespace troja.Controllers;


[ApiController]
[Route("[controller]")]
[EnableCors("MyAllowSpecificOrigins")]

public class ReservationController : ControllerBase
{
    string accountSid = "accsid" ;      // wpisz sid
    string authToken = "token";         // wpisz token

    private readonly DataContext _context;

    public ReservationController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<List<Reservation>>> AddReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        var resIdTravel = reservation.Idtravel;
        var resNoP = reservation.Nop;
        var dbRemslots = _context.Travels.Find(resIdTravel);

        _context.Travels.Update(dbRemslots);
        
        var entity = _context.Travels.FirstOrDefault(x => x.Idtravel == resIdTravel);
        if (entity != null)
        {
            entity.Remslots -= resNoP;
            await _context.SaveChangesAsync();
        }
        
        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: "Witamy! Twoja rezerwacja została przyjęta i czeka na potwierdzenie. Biuro podróży Troja ",
            from: new Twilio.Types.PhoneNumber("+twilnum"), // wpisz nr
            to: new Twilio.Types.PhoneNumber("+mynum")      // wpisz nr
        );
        
        
        return Ok(await _context.Reservations.ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Reservation>>> GetAllReservations()
    {
        return Ok(await _context.Reservations.ToListAsync());
    }

    [HttpGet("/Reservation/Count")]
    public int Count()
    {
        var count = _context.Reservations.Count();
        return count;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllReservations()
    {
        var reservations = await _context.Reservations.ToListAsync();
        _context.Reservations.RemoveRange(reservations);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{IdReservation}")]
    public async Task<ActionResult<List<Reservation>>> GetReservation(int idreservation)
    {
        var reservation = await _context.Reservations.FindAsync(idreservation);

        if (reservation == null)
        {
            return BadRequest("Reservation not found");
        }

        return Ok(reservation);
    }
    
}