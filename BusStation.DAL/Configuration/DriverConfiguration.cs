using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.DAL.Configuration;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder
            .HasKey(d => d.Id);
        
        builder
            .Property(d => d.DriverPib)
            .IsRequired();
        
        builder
            .Property(d => d.DriverPhoneNumber)
            .IsRequired();

        builder
            .Property(d => d.Mail)
            .IsRequired();
        
        builder
            .HasOne(d => d.Car)
            .WithOne(c => c.Driver)
            .HasForeignKey<Driver>(d => d.CarId);
    }
}
