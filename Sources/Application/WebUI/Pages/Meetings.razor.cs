using Microsoft.AspNetCore.Components;
using Mmu.EfCoreSecurity.WebUI.Data;
using Mmu.EfCoreSecurity.WebUI.ViewModels;

namespace Mmu.EfCoreSecurity.WebUI.Pages
{
    public partial class Meetings
    {
        public IReadOnlyCollection<MeetingOverviewEntryViewModel>? OverviewEntries { get; private set; }

        [Inject]
        public IMeetingService MeetingService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            OverviewEntries = await MeetingService.LoadOverviewAsync();
        }
    }
}
