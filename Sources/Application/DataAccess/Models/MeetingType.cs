using System.Diagnostics.CodeAnalysis;

namespace Mmu.EfCoreSecurity.DataAccess.Models
{
    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Business terms")]
    public enum MeetingType
    {
        Short,
        Long
    }
}