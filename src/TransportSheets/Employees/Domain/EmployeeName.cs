using ValueOf;

namespace Rusell.TransportSheets.Employees.Domain;

public class EmployeeName : ValueOf<string, EmployeeName>
{
    public static implicit operator string(EmployeeName employeeName) => employeeName.Value;
    public static implicit operator EmployeeName(string employeeName) => From(employeeName);
}
