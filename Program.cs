using CyberTech_Backend.Data;
using CyberTech_Backend.Hubs;
using CyberTech_Backend.Repository;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using System.Text;


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
        builder.Services.AddSignalR();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {

                Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey

            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        // Add Repositories
        builder.Services.AddScoped<ICyberTechRepository, CyberTechRepository>();
        builder.Services.AddScoped<IMoveRepository, MoveRepository>();
        builder.Services.AddScoped<ITypeRepository, TypeRepository>();
        builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

        // Add Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "CyberTech-Backend",
                ValidAudience = "CyberTech-Client",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value))
            };
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHub<GameHub>("/GameHub");
        app.MapControllers();

        app.Run();
    }
}
