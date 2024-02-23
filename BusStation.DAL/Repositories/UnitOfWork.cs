using BusStation.DAL.Interfaces;

namespace BusStation.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly BusStationContext databaseContext;
    public ICarRepository CarRepository { get; }
    public IDriverRepository DriverRepository { get; }
    public IFlightRepository FlightRepository { get; }
    public IRouteRepository RouteRepository { get; }
    public IScheduleRepository ScheduleRepository { get; }
    public ITicketRepository TicketRepository { get; }

    public UnitOfWork(
        BusStationContext databaseContext,
        ICarRepository carRepository,
        IDriverRepository driverRepository, 
        IFlightRepository flightRepository,
        IRouteRepository routeRepository,
        IScheduleRepository scheduleRepository,
        ITicketRepository ticketRepository)
    {
        this.databaseContext = databaseContext;
        CarRepository = carRepository;
        DriverRepository = driverRepository;
        FlightRepository = flightRepository;
        RouteRepository = routeRepository;
        ScheduleRepository = scheduleRepository;
        TicketRepository = ticketRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}