using ValueOf;

namespace Rusell.TransportSheets.Domain;

public class TransportSheetId : ValueOf<Guid, TransportSheetId>
{
    public static implicit operator Guid(TransportSheetId transportSheetId) => transportSheetId.Value;
    public static implicit operator TransportSheetId(Guid transportSheetId) => From(transportSheetId);
}
