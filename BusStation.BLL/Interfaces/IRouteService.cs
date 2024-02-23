using BusStation.Data.DataTransferObjects;
using BusStation.Data.Interfaces;

namespace BusStation.BLL.Interfaces;

public interface IRouteService
{
    Task<IBaseResponse<RouteDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<RouteDto>>> Get();
    Task<IBaseResponse<string>> Insert(RouteDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}