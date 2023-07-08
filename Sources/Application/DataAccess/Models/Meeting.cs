using Mmu.EfCoreSecurity.WebUI.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.WebUI.DataAccess.Models;

public class Meeting : EntityBase
{
    public List<Participant> Participants { get; set; }

    public Agenda? Agenda { get; set; }
    public MeetingType MeetingType { get; set; }
    public string Name { get; set; }
}