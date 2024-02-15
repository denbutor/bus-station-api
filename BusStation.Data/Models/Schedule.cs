namespace BusStation.Data.Models;

public class Schedule
{
    public string WeekDay { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public float TicketCost { get; set; }
    public ICollection<Flight> Flights { get; set; } = null!;
}