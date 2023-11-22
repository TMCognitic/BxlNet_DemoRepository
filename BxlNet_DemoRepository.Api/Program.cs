
using BxlNet_DemoRepository.Models.Repositories;
using BxlNet_DemoRepository.Models.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace BxlNet_DemoRepository.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<DbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IMovieRepository, MovieService>();

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
}
