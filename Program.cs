using CyberTech_Backend.Data;
using CyberTech_Backend.Repository;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyberTech_Backend;

public class Program
{
    public static void Main(string[] args)
    {
       
        var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json")
    .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<CyberTech_APIContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Add Repositories
        builder.Services.AddScoped<ICyberTechRepository, CyberTechRepository>();
        builder.Services.AddScoped<IMoveRepository, MoveRepository>();
        builder.Services.AddScoped<ITypeRepository, TypeRepository>();
        builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
