using Microsoft.EntityFrameworkCore;
using StudiesAPI.Data;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Data.Repositories;
using StudiesAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IRepository<Guest, Guid>, Repository<Guest, Guid>>();
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
