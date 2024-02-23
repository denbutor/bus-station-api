using BusStation.Data.DataTransferObjects;
using BusStation.Data.Interfaces;

namespace BusStation.BLL.Interfaces;

public interface IScheduleService
{
    Task<IBaseResponse<ScheduleDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<ScheduleDto>>> Get();
    Task<IBaseResponse<string>> Insert(ScheduleDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}