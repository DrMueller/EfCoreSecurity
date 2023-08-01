using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mmu.EfCoreSecurity.Common.Security.Services;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts.Implementation;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Interceptors;
using Mmu.EfCoreSecurity.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories.Implementation;

public class AppDbContextFactory : IAppDbContextFactory
{
    private readonly IServiceProvider _services;

    public AppDbContextFactory(IServiceProvider services)
    {
        _services = services;
    }

    public IAppDbContext Create()
    {
        //var options = new DbContextOptionsBuilder()
        //    .UseInMemoryDatabase("tra123")
        //    .EnableSensitiveDataLogging()
        //    .AddInterceptors(_services.GetRequiredService<ISecurityInterceptor>())
        //    .Options;

            var options = new DbContextOptionsBuilder()
                .UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TestEfCore;Data Source=N297\\SQLEXPRESS;Trusted_Connection=True;TrustServerCertificate=True")
                .EnableSensitiveDataLogging()
                .AddInterceptors(_services.GetRequiredService<ISecurityInterceptor>())
                .Options;
            var context = new AppDbContext(
            options,
            _services.GetRequiredService<IEntitySecurityDispatcher>());

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        SeedData(context);

        return context;
    }

    private void SeedData(AppDbContext context)
    {
        if (context.DbSet<Meeting>().AsNoTracking().Any()) return;

        context.Add(new Meeting
        {
            //Id = i,
            Agenda = new Agenda
            {
                AgendaPoint = "AgendaPoint admin",
                CreatedUserId = "admin"
            },
            MeetingType = MeetingType.Long,
            Name = "Agenda Name ",
            Participants = CreateParticipants(1)
        });

        context.Add(new Meeting
        {
            //Id = i,
            Agenda = new Agenda
            {
                AgendaPoint = "AgendaPoint admin",
                CreatedUserId = "user1"
            },
            MeetingType = MeetingType.Long,
            Name = "Agenda Name ",
            Participants = CreateParticipants(1)
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