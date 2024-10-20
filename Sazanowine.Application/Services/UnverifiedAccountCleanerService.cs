using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Services;

public class UnverifiedAccountCleanerService(IServiceProvider services) : BackgroundService
{
    private readonly IServiceProvider _services = services;
    private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(30);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await CleanUnverifiedAccountsAsync();
            await Task.Delay(_checkInterval, stoppingToken);
        }
    }

    private async Task CleanUnverifiedAccountsAsync()
    {
        using var scope = _services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var expirationTime = DateTime.UtcNow.AddHours(-1); 
        var unverifiedUsers = await userManager.Users
            .Where(u => !u.EmailConfirmed && u.MailTokenExpireTime < expirationTime)
            .AsNoTracking()
            .ToListAsync();

        foreach (var user in unverifiedUsers)
        {
            await userManager.DeleteAsync(user);
        }
    }
}