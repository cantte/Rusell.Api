using ValueOf;

namespace Rusell.Parcels.Domain;

public class VehicleLicensePlate : ValueOf<string, VehicleLicensePlate>
{
    public static implicit operator string(VehicleLicensePlate vehicleLicensePlate) => vehicleLicensePlate.Value;
    public static implicit operator VehicleLicensePlate(string vehicleLicensePlate) => From(vehicleLicensePlate);
}
