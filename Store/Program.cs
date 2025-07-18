
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using presistence.Data;
using presistence.Repositories;
using Services;
using Services.Abstraction;
using Services.MappingProfile;
using System;
using System.Reflection;

namespace Store
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext> (option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Defualte"));
            } );
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(AssemblyRefrence).Assembly);

            var app = builder.Build();
            
            #region Initialize Db
                
            //un manage resource have all services
            using var scope= app.Services.CreateScope();
             var dbIni=scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbIni.InitializeAsync();

            #endregion

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
