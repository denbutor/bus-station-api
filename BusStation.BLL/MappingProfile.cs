using AutoMapper;
using BusStation.Data.DataTransferObjects;
using BusStation.Data.Models;

namespace BusStation.BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
        
        CreateMap<Driver, DriverDto>();
        CreateMap<DriverDto, Driver>();
        
        CreateMap<Flight, FlightDto>();
        CreateMap<FlightDto, Flight>();
        
        CreateMap<Route, RouteDto>();
        CreateMap<RouteDto, Route>();
        
        CreateMap<Schedule, ScheduleDto>();
        CreateMap<ScheduleDto, Schedule>();
        
        CreateMap<Ticket, TicketDto>();
        CreateMap<TicketDto, Ticket>();
    }
}