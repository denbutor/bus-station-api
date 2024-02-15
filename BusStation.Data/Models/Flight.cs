namespace BusStation.Data.Models;

public class Flight
{
    public DateTime Date { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public float TicketCost { get; set; }
    public ICollection<Route> Routes { get; set; } = null!;
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; } = null!;

    
}