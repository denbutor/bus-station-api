namespace BusStation.Data.DataTransferObjects;

public class DriverDto : BaseDto
{
    public string DriverPIB { get; set; } = string.Empty;
    public string DriverPhoneNumber { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public Guid CarId { get; set; }
}