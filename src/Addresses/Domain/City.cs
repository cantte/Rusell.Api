using ValueOf;

namespace Rusell.Addresses.Domain;

public class City : ValueOf<string, City>
{
    public static implicit operator string(City city) => city.Value;
    public static implicit operator City(string city) => From(city);
}
