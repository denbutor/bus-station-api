using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.DAL.Configuration;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder
            .HasKey(r => r.Id);
        
        builder
            .Property(r => r.Start)
            .IsRequired();
        
        builder
            .Property(r => r.Finish)
            .IsRequired();

        builder
            .Property(r => r.Distance)
            .IsRequired();
        
        builder
            .Property(r => r.Duration)
            .IsRequired();
        
        builder
            .Property(r => r.FlightId)
            .IsRequired();

        builder
            .HasOne(r => r.Flight)
            .WithOne(f => f.Route)
            .HasForeignKey<Route>(r => r.FlightId);
    }
}
