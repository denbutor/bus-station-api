namespace BusStation.Data.Models;

public class Car : BaseModel
{
    public string CarType { get; set; } = string.Empty;
    public int CarNumber { get; set; }
    public int PassengersCount { get; set; }
}