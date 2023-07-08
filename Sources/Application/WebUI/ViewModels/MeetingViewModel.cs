namespace Mmu.EfCoreSecurity.WebUI.ViewModels
{
    public class MeetingViewModel
    {
        public AgendaViewModel Agenda { get; init; }

        public IReadOnlyCollection<ParticipantViewModel> Participants { get; init; }
    }
}
