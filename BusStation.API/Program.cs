using BusStation.BLL;
using BusStation.BLL.Interfaces;
using BusStation.BLL.Services;
using BusStation.DAL;
using BusStation.DAL.Interfaces;
using BusStation.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BusStationContext>(options =>
    options.UseSqlite("Data Source=RecordsDatabase.db")
);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ITicketService, TicketService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();