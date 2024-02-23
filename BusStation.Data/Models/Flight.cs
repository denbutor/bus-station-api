namespace BusStation.Data.Models;

public class Flight : BaseModel
{
    public DateTime Date { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public float TicketCost { get; set; }
    public Route Route { get; set; } = null!;
    public Guid RouteId { get; set; }
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; } = null!;
    

    
}