using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Companies.Domain;

namespace Rusell.Routes.Domain;

public class Route
{
    public Route()
    {
        Id = RouteId.From(Guid.NewGuid());
    }

    public RouteId Id { get; set; }

    public AddressId FromId { get; set; }
    public Address From { get; set; }

    public AddressId ToId { get; set; }
    public Address To { get; set; }

    public Cost Cost { get; set; }

    /// <summary>
    ///     Indicates if passengers are picked up at home before starting the route.
    /// </summary>
    public IsCustomerPickedUpAtHome IsCustomerPickedUpAtHome { get; set; }

    /// <summary>
    ///     Indicates if passengers are delivered to their homes at the end of the route.
    /// </summary>
    public IsCustomerDroppedOffAtHome IsCustomerDroppedOffAtHome { get; set; }

    public CompanyId CompanyId { get; set; }
    public Company Company { get; set; }

    public static Route Create(AddressId fromId, AddressId toId, Cost cost,
        IsCustomerPickedUpAtHome isCustomerPickedUpAtHome,
        IsCustomerDroppedOffAtHome isCustomerDroppedOffAtHome, CompanyId companyId) =>
        new()
        {
            FromId = fromId,
            ToId = toId,
            Cost = cost,
            IsCustomerPickedUpAtHome = isCustomerPickedUpAtHome,
            IsCustomerDroppedOffAtHome = isCustomerDroppedOffAtHome,
            CompanyId = companyId
        };
}
