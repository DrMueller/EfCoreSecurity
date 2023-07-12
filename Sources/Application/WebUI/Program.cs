using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Mmu.EfCoreSecurity.Common.Security.Services;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services.Strategies;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories.Implementation;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Interceptors;
using Mmu.EfCoreSecurity.DataAccess.Models;
using Mmu.EfCoreSecurity.DataAccess.Querying;
using Mmu.EfCoreSecurity.DataAccess.Querying.Implementation;
using Mmu.EfCoreSecurity.DataAccess.Repositories;
using Mmu.EfCoreSecurity.DataAccess.Repositories.Implementation;
using Mmu.EfCoreSecurity.WebUI.Data;
using Mmu.EfCoreSecurity.WebUI.Security.Services;

namespace Mmu.EfCoreSecurity.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<IMeetingService, MeetingService>();
            builder.Services.AddScoped<IQueryService, QueryService>();
            builder.Services.AddScoped<IAppDbContextFactory, AppDbContextFactory>();
            builder.Services.AddScoped<ISecurityInterceptor, SecurityInterceptor>();

            builder.Services.AddScoped<IEntitySecurityDispatcher, EntitySecurityDispatcher>();
            builder.Services.AddScoped<IUserProvider, UserProvider>();

            builder.Services.AddScoped<IEntitySecurityHandler<Agenda>, AgendaHandler>();
            builder.Services.AddScoped<IEntitySecurityHandler<Meeting>, MeetingHandler>();

            builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}