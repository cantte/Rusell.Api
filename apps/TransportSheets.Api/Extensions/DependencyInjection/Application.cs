using Rusell.Shared;
using Rusell.Shared.Helpers;
using Rusell.TransportSheets.Application.Create;
using Rusell.TransportSheets.Application.FindCurrent;
using Rusell.TransportSheets.Application.SearchAllByCompany;
using Rusell.TransportSheets.Employees.Application.Create;

namespace Rusell.TransportSheets.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TransportSheetCreator, TransportSheetCreator>();
        services.AddScoped<TransportSheetsByCompanySearcher, TransportSheetsByCompanySearcher>();
        services.AddScoped<CurrentTransportSheetFinder, CurrentTransportSheetFinder>();

        services.AddScoped<EmployeeCreator, EmployeeCreator>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.TransportSheets));

        return services;
    }
}
