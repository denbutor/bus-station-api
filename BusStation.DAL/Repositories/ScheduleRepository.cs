using BusStation.DAL.Interfaces;
using BusStation.Data.Models;

namespace BusStation.DAL.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(BusStationContext databaseContext) : base(databaseContext)
    {
    }
}