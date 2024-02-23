using BusStation.Data.DataTransferObjects;
using BusStation.Data.Interfaces;

namespace BusStation.BLL.Interfaces;

public interface ITicketService
{
    Task<IBaseResponse<TicketDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<TicketDto>>> Get();
    Task<IBaseResponse<string>> Insert(TicketDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}