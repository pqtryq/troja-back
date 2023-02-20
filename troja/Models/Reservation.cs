namespace troja.Models;

public class Reservation
{
    public int Idreservation { get; set; }
    
    public string Firstname { get; set; } 

    public string Lastname { get; set; } 
    
    public string PhoneNumber { get; set; } 
    
    public int Nop { get; set; }

    public int Idtravel { get; set; }
    
    public string Comments { get; set; } = null!;

    public DateTime Orderdatetime { get; set; } 
    
}
