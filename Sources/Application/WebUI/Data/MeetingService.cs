using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.Common.Security.Services;
using Mmu.EfCoreSecurity.DataAccess.Models;
using Mmu.EfCoreSecurity.DataAccess.Querying;
using Mmu.EfCoreSecurity.DataAccess.Repositories;
using Mmu.EfCoreSecurity.WebUI.ViewModels;

namespace Mmu.EfCoreSecurity.WebUI.Data
{
    public class MeetingService : IMeetingService
    {
        private readonly IQueryService _queryService;
        private readonly IMeetingRepository _meetingRepo;
        private readonly IUserProvider _userProvider;

        public MeetingService(IQueryService queryService, IMeetingRepository meetingRepo,
            IUserProvider userProvider)
        {
            _queryService = queryService;
            _meetingRepo = meetingRepo;
            _userProvider = userProvider;
        }

        public async Task<IReadOnlyCollection<MeetingOverviewEntryViewModel>> LoadOverviewAsync()
        {
            return await _queryService
                .QueryAsync<Meeting, List<MeetingOverviewEntryViewModel>> (async qry =>
                {
                    return await qry
                        .Include(f => f.Participants)
                        .Include(f => f.Agenda)
                        .Select(f => new MeetingOverviewEntryViewModel
                        {
                            AmountOfParticipants = f.Participants.Count,
                            HasAgenda = f.Agenda != null,
                            MeetingName = f.Name,
                            MeetingId = f.Id
                        }).ToListAsync();
                });
        }

        public async Task<MeetingViewModel> LoadMeetingAsync(long id)
        {
            if (id == 0)
            {
                return new MeetingViewModel();
            }

            return await _queryService
                .QueryAsync<Meeting, MeetingViewModel>(async qry =>
                {
                    var tra = await qry.Include(f => f.Agenda)
                        .Include(f => f.Participants)
                        .Where(f => f.Id == id)
                        .Select(f => new MeetingViewModel
                        {
                            AgendaPoint = f.Agenda.AgendaPoint,
                            MeetingId = f.Id,
                            MeetingName = f.Name
                        }).SingleAsync();

                    return tra;
                });
        }
       
        public async Task SaveMeetingAsync(MeetingViewModel vm)
        {
            Meeting meeting;
            if (vm.MeetingId != 0)
            {
                meeting = await _meetingRepo.LoadAsync(vm.MeetingId);
            }
            else
            {
                meeting = new Meeting
                {
                    Agenda = new Agenda
                    {
                        CreatedUserId = _userProvider.ProvideUser().UserId,
                    },
                    Participants = new List<Participant>()
                };
            }

            meeting.Name = vm.MeetingName;
            meeting.Agenda.AgendaPoint = vm.AgendaPoint;

            await _meetingRepo.SaveAsync(meeting);
        }
    }
}
