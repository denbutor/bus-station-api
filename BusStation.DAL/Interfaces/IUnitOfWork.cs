namespace BusStation.DAL.Interfaces;

public interface IUnitOfWork
{
    ICarRepository CarRepository { get; }
    IDriverRepository DriverRepository { get; }
    IFlightRepository FlightRepository { get; }
    IRouteRepository RouteRepository { get; }
    IScheduleRepository ScheduleRepository { get; }
    ITicketRepository TicketRepository { get; }
    Task SaveChangesAsync();
}