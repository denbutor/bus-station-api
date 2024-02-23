using AutoMapper;
using BusStation.BLL.Interfaces;
using BusStation.DAL.Interfaces;
using BusStation.Data.DataTransferObjects;
using BusStation.Data.Enums;
using BusStation.Data.Interfaces;
using BusStation.Data.Models;
using BusStation.Data.Responses;

namespace BusStation.BLL.Services;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IBaseResponse<TicketDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<TicketDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.TicketRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<TicketDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<TicketDto>();
                
            foreach (var model in models)
                dtoList.Add(_mapper.Map<TicketDto>(model));
                
            return CreateBaseResponse<IEnumerable<TicketDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<TicketDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> Insert(TicketDto? modelDto)
    {
        try
        {
            if (modelDto is not null)
            {
                modelDto.Id = Guid.NewGuid();
                
                await _unitOfWork.TicketRepository.InsertAsync(_mapper.Map<Ticket>(modelDto));
                await _unitOfWork.SaveChangesAsync();

                return CreateBaseResponse<string>("Object inserted!", StatusCode.Ok, resultsCount: 1);
            }

            return CreateBaseResponse<string>("Objet can`t be empty...", StatusCode.BadRequest);
        }
        catch (Exception e)
        {
            return CreateBaseResponse<string>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> DeleteById(Guid id)
    {
        try
        {
            await _unitOfWork.TicketRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return CreateBaseResponse<string>("Object deleted!", StatusCode.Ok, resultsCount: 1);
        }
        catch (Exception e)
        {
            return CreateBaseResponse<string>($"{e.Message} or object not found", StatusCode.InternalServerError);
        }
    }
    
    private BaseResponse<T> CreateBaseResponse<T>(string description, StatusCode statusCode, T? data = default, int resultsCount = 0)
    {
        return new BaseResponse<T>()
        {
            ResultsCount = resultsCount,
            Data = data!,
            Description = description,
            StatusCode = statusCode
        };
    }
}