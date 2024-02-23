namespace BusStation.Data.DataTransferObjects;

public class RouteDto : BaseDto
{
    public string Start { get; set; } = string.Empty;
    public string Finish { get; set; } = string.Empty;
    public int Distance { get; set; }
    public DateTime Duration { get; set; }
    public Guid FlightId { get; set; }
    
}