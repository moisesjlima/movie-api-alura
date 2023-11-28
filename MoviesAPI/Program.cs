using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

namespace MoviesAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var MovieCon = builder.Configuration.GetConnectionString("MovieCon");

        builder.Services.AddDbContext<MovieContext>(opts =>
        {
            opts.UseMySql(MovieCon, ServerVersion.AutoDetect(MovieCon));
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddControllers().AddNewtonsoftJson();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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