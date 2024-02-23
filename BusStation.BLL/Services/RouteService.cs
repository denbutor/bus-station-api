using AutoMapper;
using BusStation.BLL.Interfaces;
using BusStation.DAL.Interfaces;
using BusStation.Data.DataTransferObjects;
using BusStation.Data.Enums;
using BusStation.Data.Interfaces;
using BusStation.Data.Models;
using BusStation.Data.Responses;

namespace BusStation.BLL.Services;

public class RouteService : IRouteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RouteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IBaseResponse<RouteDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<RouteDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.RouteRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<RouteDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<RouteDto>();
                
            foreach (var model in models)
                dtoList.Add(_mapper.Map<RouteDto>(model));
                
            return CreateBaseResponse<IEnumerable<RouteDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<RouteDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> Insert(RouteDto? modelDto)
    {
        try
        {
            if (modelDto is not null)
            {
                modelDto.Id = Guid.NewGuid();
                
                await _unitOfWork.RouteRepository.InsertAsync(_mapper.Map<Route>(modelDto));
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
            await _unitOfWork.RouteRepository.DeleteAsync(id);
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