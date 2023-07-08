using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.DataAccess.Querying;
using Mmu.EfCoreSecurity.WebUI.DataAccess.Models;
using Mmu.EfCoreSecurity.WebUI.ViewModels;

namespace Mmu.EfCoreSecurity.WebUI.Data
{
    public class MeetingService : IMeetingService
    {
        private readonly IQueryService _queryService;

        public MeetingService(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<MeetingOverviewEntryViewModel>> LoadOverviewAsync()
        {
            return await _queryService
                .QueryAsync<Meeting, List< MeetingOverviewEntryViewModel >> (async qry =>
                {
                    return await qry
                        .Include(f => f.Participants)
                        .Include(f => f.Agenda)
                        .Select(f => new MeetingOverviewEntryViewModel
                        {
                            AmountOfParticipants = f.Participants.Count,
                            HasAgenda = f.Agenda != null,
                            MeetingName = f.Name
                        }).ToListAsync();
                });
        }
    }
}
