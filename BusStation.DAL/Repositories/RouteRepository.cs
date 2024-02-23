using BusStation.DAL.Interfaces;
using BusStation.Data.Models;

namespace BusStation.DAL.Repositories;

public class RouteRepository : GenericRepository<Route>, IRouteRepository
{
    public RouteRepository(BusStationContext databaseContext) : base(databaseContext)
    {
    }
}