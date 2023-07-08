using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts.Implementation;
using Mmu.EfCoreSecurity.WebUI.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories.Implementation;

public class AppDbContextFactory : IAppDbContextFactory
{
    private readonly Lazy<DbContextOptions> _lazyOptions;

    public AppDbContextFactory()
    {
        _lazyOptions = new Lazy<DbContextOptions>(
            () => new DbContextOptionsBuilder()
                .UseInMemoryDatabase("tra123")
                .EnableSensitiveDataLogging()
                .Options);
    }

    public IAppDbContext Create()
    {
        var context = new AppDbContext(_lazyOptions.Value);
        SeedData(context);

        return context;
    }

    private void SeedData(AppDbContext context)
    {
        if (context.DbSet<Meeting>().AsNoTracking().Any()) return;

        for (var i = 1; i <= 10; i++)
            context.Add(new Meeting
            {
                //Id = i,
                Agenda = new Agenda
                {
                    Id = 10 + i,
                    AgendaPoint = "AgendaPoint " + 100 + i
                },
                MeetingType = MeetingType.Long,
                Name = "Agenda Name " + i,
                Participants = CreateParticipants(i)
            });

        context.SaveChanges();
    }

    private List<Participant> CreateParticipants(int i)
    {
        var result = new List<Participant>();

        for (var j = 0; j <= i; j++)
            result.Add(new Participant
            {
                //Id = j + 200 + (i * 1000),
                Name = "Participant " + j + i + 200
            });

        return result;
    }
}