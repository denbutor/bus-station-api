using BusStation.DAL.Interfaces;
using BusStation.Data.Models;

namespace BusStation.DAL.Repositories;

public class CarRepository : GenericRepository<Car>, ICarRepository
{
    public CarRepository(BusStationContext databaseContext) : base(databaseContext)
    {
    }
}