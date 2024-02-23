using BusStation.DAL.Interfaces;
using BusStation.Data.Models;

namespace BusStation.DAL.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(BusStationContext databaseContext) : base(databaseContext)
    {
    }
}