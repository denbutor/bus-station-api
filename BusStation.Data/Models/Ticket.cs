namespace BusStation.Data.Models;

public class Ticket
{
    public string PassengersName { get; set; } = string.Empty;
    public string OnlineTicket { get; set; } = string.Empty;
    public bool SaleStatus { get; set; }
    public ICollection<Flight> Flights { get; set; } = null!;
    public Guid FlightId { get; set; }
    public Flight Flight { get; set; } = null!;

}