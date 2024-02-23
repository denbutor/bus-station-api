using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.DAL.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasKey(t => t.Id);
        
        builder
            .Property(t => t.PassengersName)
            .IsRequired();
        
        builder
            .Property(t => t.OnlineTicket)
            .IsRequired();

        builder
            .Property(t => t.SaleStatus)
            .IsRequired(); 
        
        builder
            .HasOne(t => t.Flight)
            .WithMany(f => f.Tickets)
            .HasForeignKey(t => t.FlightId);
        
    }
}
