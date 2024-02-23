namespace BusStation.Data.DataTransferObjects;

public class CarDto : BaseDto
{
    public string CarType { get; set; } = string.Empty;
    public int CarNumber { get; set; }
    public int PassengersCount { get; set; }
    public Guid DriverId { get; set; }
    
}