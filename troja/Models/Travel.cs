namespace troja.Models;

public class Travel
{
    public int Idtravel { get; set; }

    public int Idcountry { get; set; }

    public string Location { get; set; } = null!;

    public string Hotel { get; set; } = null!;

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }

    public double Price { get; set; }

    public string Xcord { get; set; } = null!;

    public string Ycord { get; set; } = null!;

    public int Slots { get; set; }

    public int Remslots { get; set; }
    
}
