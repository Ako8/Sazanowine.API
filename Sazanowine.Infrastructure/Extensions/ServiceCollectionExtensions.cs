using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sazanowine.Application.Services;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Persistence;
using Sazanowine.Infrastructure.Repositories;
using Sazanowine.Infrastructure.Seeders;
using System;

namespace Sazanowine.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        var connectionString = configuration.GetConnectionString("SazanowineDb");
        services.AddDbContext<SazanowineDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
            if(environment.IsDevelopment())
            {
                option.EnableSensitiveDataLogging();    
            }
                
        });

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SazanowineDbContext>();

        services.AddHostedService<UnverifiedAccountCleanerService>();

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ISazanowineSeeder, SazanowineSeeder>();
        services.AddScoped<IRoomRepositorie, RoomRepositorie>();
        services.AddScoped<IWineRepositorie, WineRepositorie>();
        services.AddScoped<IOrderRepositorie, OrderRepositorie>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}