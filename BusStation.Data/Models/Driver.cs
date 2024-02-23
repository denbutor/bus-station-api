namespace BusStation.Data.Models;

public class Driver : BaseModel
{
    public string DriverPib { get; set; } = string.Empty;
    public string DriverPhoneNumber { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    
    public Guid CarId { get; set; }
    
    public Car Car { get; set; } = null!;
}