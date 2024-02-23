using BusStation.DAL.Interfaces;
using BusStation.Data.Models;

namespace BusStation.DAL.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(BusStationContext databaseContext) : base(databaseContext)
    {
    }
}