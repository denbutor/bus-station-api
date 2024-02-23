using AutoMapper;
using BusStation.BLL.Interfaces;
using BusStation.DAL.Interfaces;
using BusStation.Data.DataTransferObjects;
using BusStation.Data.Enums;
using BusStation.Data.Interfaces;
using BusStation.Data.Models;
using BusStation.Data.Responses;

namespace BusStation.BLL.Services;

public class FlightService : IFlightService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IBaseResponse<FlightDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<FlightDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.FlightRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<FlightDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<FlightDto>();
                
            foreach (var model in models)
                dtoList.Add(_mapper.Map<FlightDto>(model));
                
            return CreateBaseResponse<IEnumerable<FlightDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<FlightDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> Insert(FlightDto? modelDto)
    {
        try
        {
            if (modelDto is not null)
            {
                modelDto.Id = Guid.NewGuid();
                
                await _unitOfWork.FlightRepository.InsertAsync(_mapper.Map<Flight>(modelDto));
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
            await _unitOfWork.FlightRepository.DeleteAsync(id);
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