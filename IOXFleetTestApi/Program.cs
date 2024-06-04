using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Persistence;
using IOXFleetTestApi.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add db connection.
builder
    .Services
    .AddDbContext<FleetTestDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("FleetTestDb"),
        opt => opt.MigrationsAssembly("IOXFleetTest.Persistence")));

builder.Services.AddRepositories();

builder
    .Services
    .AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(IOXFleetTest.Application.AssemblyReference.Assembly);
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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