using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
using Rusell.Shared.Infrastructure.Persistence;
using Rusell.Vehicles.Domain;
using Rusell.Vehicles.Employees.Domain;
using Rusell.Vehicles.Employees.Infrastructure.Persistence;
using Rusell.Vehicles.Infrastructure.Persistence;
using Rusell.Vehicles.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.Vehicles.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);

        services.AddDbContext<VehiclesDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<VehiclesDbContext, VehiclesDbContext>();
        services.AddScoped<DbContext, VehiclesDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Vehicles));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        services.AddScoped<IVehiclesRepository, EntityFrameworkVehiclesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddScoped<IEventBus, RabbitMqEventBus>();
        services.AddScoped<IEventBusConfiguration, RabbitMqEventBusConfiguration>();
        services.AddScoped<IDomainEventsConsumer, RabbitMqDomainEventsConsumer>();
        services.AddScoped<DomainEventsInformation, DomainEventsInformation>();

        services.AddRabbitMq(configuration);
        services.AddScoped<IDomainEventDeserializer, DomainEventJsonDeserializer>();

        services.AddHostedService<RabbitMqBusSubscriber>();

        return services;
    }

    private static void AddBearerTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                c =>
                {
                    c.Authority = $"https://{configuration["Auth0:Domain"]}/";
                    c.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = configuration["Auth0:Audience"],
                        ValidIssuer = $"{configuration["Auth0:Domain"]}"
                    };
                });
    }

    private static void AddRabbitMq(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<RabbitMqPublisher, RabbitMqPublisher>();
        services.AddScoped<RabbitMqConfig, RabbitMqConfig>();
        services.Configure<RabbitMqConfigParams>(configuration.GetSection("RabbitMq"));
    }
}
