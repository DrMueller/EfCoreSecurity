using Mmu.EfCoreSecurity.WebUI.DataAccess.Models;
using Mmu.EfCoreSecurity.WebUI.ViewModels;

namespace Mmu.EfCoreSecurity.WebUI.Data
{
    public interface IMeetingService
    {
        Task<IReadOnlyCollection<MeetingOverviewEntryViewModel>> LoadOverviewAsync();
    }
}
