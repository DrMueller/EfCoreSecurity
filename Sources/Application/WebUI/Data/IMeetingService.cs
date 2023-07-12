using Mmu.EfCoreSecurity.WebUI.ViewModels;

namespace Mmu.EfCoreSecurity.WebUI.Data
{
    public interface IMeetingService
    {
        Task<IReadOnlyCollection<MeetingOverviewEntryViewModel>> LoadOverviewAsync();

        Task<MeetingViewModel> LoadMeetingAsync(long id);

        Task SaveMeetingAsync(MeetingViewModel vm);
    }
}
