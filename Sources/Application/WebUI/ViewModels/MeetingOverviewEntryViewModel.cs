namespace Mmu.EfCoreSecurity.WebUI.ViewModels
{
    public class MeetingOverviewEntryViewModel
    {
        public long MeetingId { get; set; }

        public bool HasAgenda { get; init; }

        public int AmountOfParticipants { get; init; }

        public string MeetingName { get; init; }
    }
}
