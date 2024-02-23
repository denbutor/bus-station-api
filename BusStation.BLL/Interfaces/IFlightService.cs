using BusStation.Data.DataTransferObjects;
using BusStation.Data.Interfaces;

namespace BusStation.BLL.Interfaces;

public interface IFlightService
{
    Task<IBaseResponse<FlightDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<FlightDto>>> Get();
    Task<IBaseResponse<string>> Insert(FlightDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}