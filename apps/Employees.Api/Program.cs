using Rusell.Employees.Api.Extensions.DependencyInjection;
using Rusell.Employees.Api.Grpc;
using Rusell.Employees.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();
builder.Services.AddGrpc();
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.MigrateDatabase<EmployeesDbContext>();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGrpcService<EmployeesService>();

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
namespace Rusell.Employees.Api
{
    public class Program
    {
        // For testing purposes
    }
}
#pragma warning restore CA1050 // Declare types in namespaces
