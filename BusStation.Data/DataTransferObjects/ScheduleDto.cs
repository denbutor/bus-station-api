namespace BusStation.Data.DataTransferObjects;

public class ScheduleDto : BaseDto
{
    public string WeekDay { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public float TicketCost { get; set; }
    
}