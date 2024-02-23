namespace BusStation.Data.DataTransferObjects;

public class TicketDto : BaseDto
{
    public string PassengersName { get; set; } = string.Empty;
    public string OnlineTicket { get; set; } = string.Empty;
    public bool SaleStatus { get; set; }
    public Guid FlightId { get; set; }

}