using AutoMapper;
using BusStation.BLL.Interfaces;
using BusStation.DAL.Interfaces;
using BusStation.Data.DataTransferObjects;
using BusStation.Data.Enums;
using BusStation.Data.Interfaces;
using BusStation.Data.Models;
using BusStation.Data.Responses;

namespace BusStation.BLL.Services;

public class DriverService : IDriverService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IBaseResponse<DriverDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<DriverDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.DriverRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<DriverDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<DriverDto>();
                
            foreach (var model in models)
                dtoList.Add(_mapper.Map<DriverDto>(model));
                
            return CreateBaseResponse<IEnumerable<DriverDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<DriverDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    // public async Task<IBaseResponse<string>> Insert(DriverDto? modelDto)
    // {
    //     try
    //     {
    //         if (modelDto is not null)
    //         {
    //             modelDto.Id = Guid.NewGuid();
    //             
    //             await _unitOfWork.DriverRepository.InsertAsync(_mapper.Map<Driver>(modelDto));
    //             await _unitOfWork.SaveChangesAsync();
    //
    //             return CreateBaseResponse<string>("Object inserted!", StatusCode.Ok, resultsCount: 1);
    //         }
    //
    //         return CreateBaseResponse<string>("Objet can`t be empty...", StatusCode.BadRequest);
    //     }
    //     catch (Exception e)
    //     {
    //         return CreateBaseResponse<string>(e.Message, StatusCode.InternalServerError);
    //     }
    // }

    public async Task<IBaseResponse<string>> DeleteById(Guid id)
    {
        try
        {
            await _unitOfWork.DriverRepository.DeleteAsync(id);
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