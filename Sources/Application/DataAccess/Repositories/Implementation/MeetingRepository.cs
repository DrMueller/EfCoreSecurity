using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories;
using Mmu.EfCoreSecurity.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.Repositories.Implementation;

public class MeetingRepository : IMeetingRepository
{
    private readonly IAppDbContextFactory _dbContextFactory;

    public MeetingRepository(IAppDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task SaveAsync(Meeting meeting)
    {
        using var dbContext = _dbContextFactory.Create();
        await dbContext.DbSet<Meeting>().UpsertAsync(meeting);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Meeting> LoadAsync(long id)
    {
        using var dbContext = _dbContextFactory.Create();
        return await dbContext.DbSet<Meeting>().AsNoTracking()
            .Include(f => f.Agenda)
            .Include(f => f.Participants)
            .SingleAsync(f => f.Id == id);
    }
}