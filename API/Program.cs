using StudiesAPI.Data;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Data.Repositories;
using StudiesAPI.Logic.Interfaces;
using StudiesAPI.Logic.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers();

        string connectionString = builder.Configuration.GetConnectionString("Default");

        builder.Services.AddSingleton<DapperDatabaseConnector>();

        builder.Services.AddScoped<IBandRepository, BandRepository>();
        builder.Services.AddScoped<IConcertRepository, ConcertRepository>();
        builder.Services.AddScoped<IAttendedFansRepository, AttendedFansRepository>();

        builder.Services.AddScoped<IBandService, BandService>();
        builder.Services.AddScoped<IConcertService, ConcertService>();
        builder.Services.AddScoped<IAttendedFansService, AttendedFansService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAnyOrigin", x =>
            {
                x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });

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
    }
}