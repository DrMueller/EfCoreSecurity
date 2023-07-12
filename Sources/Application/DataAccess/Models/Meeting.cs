using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.Models;

public class Meeting : EntityBase
{
    public List<Participant> Participants { get; set; }

    public Agenda? Agenda { get; set; }
    public MeetingType MeetingType { get; set; }
    public string Name { get; set; }
}