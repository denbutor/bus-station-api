using BusStation.Data.Models;

namespace BusStation.Data.DataTransferObjects;

public class FlightDto : BaseDto
{
    public DateTime Date { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public float TicketCost { get; set; }
    public Guid RouteId { get; set; }
    public Guid ScheduleId { get; set; }
    
}