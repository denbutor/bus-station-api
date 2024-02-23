using System.Reflection;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusStation.DAL;

public class BusStationContext : DbContext
{
    public BusStationContext(DbContextOptions<BusStationContext> options) : base(options) { }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}