using AutoMapper;
using MediatR;
using BlitzFiles.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlitzFiles.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BlitzFilesContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BlitzFilesDB")));

            //builder.Services.AddAutoMapper(Assembly.Load("BlitzFiles.DataTransfer"));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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
        }
    }
}