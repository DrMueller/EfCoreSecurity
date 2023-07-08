using Mmu.EfCoreSecurity.WebUI.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.WebUI.DataAccess.Models;

public class Agenda : EntityBase
{
    public string AgendaPoint { get; set; }
    public long MeetingId { get; }
}