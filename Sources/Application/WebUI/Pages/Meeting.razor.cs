using Microsoft.AspNetCore.Components;
using Mmu.EfCoreSecurity.WebUI.Data;
using Mmu.EfCoreSecurity.WebUI.ViewModels;
using System;

namespace Mmu.EfCoreSecurity.WebUI.Pages
{
    public partial class Meeting
    {
        public MeetingViewModel MeetingVm { get; private set; }
        
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IMeetingService MeetingService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            MeetingVm = await MeetingService.LoadMeetingAsync(Id);
        }

        private async Task HandleValidSubmitAsync()
        {
            await MeetingService.SaveMeetingAsync(MeetingVm);
            NavigationManager.NavigateTo("/meetings");
        }
    }
}
