using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.Models;

public class Agenda : EntityBase
{
    public string CreatedUserId { get; set; }
    public string AgendaPoint { get; set; }
    public long MeetingId { get; }
}