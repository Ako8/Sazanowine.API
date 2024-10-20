using Sazanowine.API.Extensions;
using Sazanowine.API.Middleware;
using Sazanowine.Application.Extensions;
using Sazanowine.Infrastructure.Extensions;
using Sazanowine.Infrastructure.Seeders;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(
                "https://mishatch.github.io",
                "http://localhost:4200"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);


var app = builder.Build();
using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ISazanowineSeeder>();
await seeder.Seed();


// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigins");

app.UseSerilogRequestLogging();


app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<RoleBasedAuthorizationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
