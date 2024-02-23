using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.DAL.Configuration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder
            .HasKey(s => s.Id);
        
        builder
            .Property(s => s.WeekDay)
            .IsRequired();
        
        builder
            .Property(s => s.DepartureTime)
            .IsRequired();

        builder
            .Property(s => s.ArrivalTime)
            .IsRequired();
        
        builder
            .Property(s => s.TicketCost)
            .IsRequired();
        
    }
}
