using BusStation.DAL.Interfaces;
using BusStation.Data.Models;

namespace BusStation.DAL.Repositories;

public class FlightRepository : GenericRepository<Flight>, IFlightRepository
{
    public FlightRepository(BusStationContext databaseContext) : base(databaseContext)
    {
    }
}