using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.DAL.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .HasKey(c => c.Id);
        
        builder
            .Property(c => c.CarType)
            .IsRequired();
        
        builder
            .Property(c => c.CarNumber)
            .IsRequired();

        builder
            .Property(c => c.PassengersCount)
            .IsRequired();

        builder
            .HasOne(c => c.Driver)
            .WithOne(d => d.Car)
            .HasForeignKey<Car>(c => c.DriverId);

    }
}