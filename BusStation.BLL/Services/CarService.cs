using AutoMapper;
using BusStation.BLL.Interfaces;
using BusStation.DAL.Interfaces;
using BusStation.Data.DataTransferObjects;
using BusStation.Data.Enums;
using BusStation.Data.Interfaces;
using BusStation.Data.Models;
using BusStation.Data.Responses;

namespace BusStation.BLL.Services;

public class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IBaseResponse<CarDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<CarDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.CarRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<CarDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<CarDto>();
                
            foreach (var model in models)
                dtoList.Add(_mapper.Map<CarDto>(model));
                
            return CreateBaseResponse<IEnumerable<CarDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<CarDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> Insert(CarDto? modelDto)
    {
        try
        {
            if (modelDto is not null)
            {
                modelDto.Id = Guid.NewGuid();
                
                await _unitOfWork.CarRepository.InsertAsync(_mapper.Map<Car>(modelDto));
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
            await _unitOfWork.CarRepository.DeleteAsync(id);
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