namespace BusStation.Data.Models;

public class Route
{
    public string Start { get; set; } = string.Empty;
    public string Finish { get; set; } = string.Empty;
    public int Distance { get; set; }
    public DateTime Duration { get; set; }
    public Guid FlightId { get; set; }
    public Flight Flight { get; set; } = null!;
}