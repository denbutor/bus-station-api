using BusStation.Data.DataTransferObjects;
using BusStation.Data.Interfaces;

namespace BusStation.BLL.Interfaces;

public interface IDriverService
{
    Task<IBaseResponse<DriverDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<DriverDto>>> Get();
    // Task<IBaseResponse<string>> Insert(DriverDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}