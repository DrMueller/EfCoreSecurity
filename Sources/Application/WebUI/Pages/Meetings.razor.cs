using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Mmu.EfCoreSecurity.WebUI.Data;
using Mmu.EfCoreSecurity.WebUI.ViewModels;

namespace Mmu.EfCoreSecurity.WebUI.Pages
{
    public partial class Meetings
    {
        public IReadOnlyCollection<MeetingOverviewEntryViewModel>? OverviewEntries { get; private set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMeetingService MeetingService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            OverviewEntries = await MeetingService.LoadOverviewAsync();
        }

        private void NavigateToCreate()
        {
            NavigationManager.NavigateTo("/meetings/0");
        }


        private void OnDoubleClick(long meetingId)
        {
            NavigationManager.NavigateTo($"/meetings/{meetingId}");
        }
    }
}
