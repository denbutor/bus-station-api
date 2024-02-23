using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.DAL.Configuration;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder
            .HasKey(f => f.Id);
        
        builder
            .Property(f => f.Date)
            .IsRequired();
        
        builder
            .Property(f => f.DepartureTime)
            .IsRequired();

        builder
            .Property(f => f.ArrivalTime)
            .IsRequired();
        
        builder
            .Property(f => f.TicketCost)
            .IsRequired();
        
        builder
            .Property(f => f.ScheduleId)
            .IsRequired();

        builder
            .HasOne(f => f.Route)
            .WithOne(r => r.Flight)
            .HasForeignKey<Flight>(f => f.RouteId);
        
        builder
            .HasOne(f => f.Schedule)
            .WithMany(s => s.Flights)
            .HasForeignKey(f => f.ScheduleId);
    }
}
