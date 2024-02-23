using BusStation.Data.DataTransferObjects;
using BusStation.Data.Interfaces;

namespace BusStation.BLL.Interfaces;

public interface ICarService
{
    Task<IBaseResponse<CarDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<CarDto>>> Get();
    Task<IBaseResponse<string>> Insert(CarDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}