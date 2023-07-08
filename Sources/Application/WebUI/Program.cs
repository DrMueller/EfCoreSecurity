using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories;
using Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories.Implementation;
using Mmu.EfCoreSecurity.DataAccess.Querying;
using Mmu.EfCoreSecurity.DataAccess.Querying.Implementation;
using Mmu.EfCoreSecurity.WebUI.Data;

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
            builder.Services.AddSingleton<IMeetingService, MeetingService>();
            builder.Services.AddSingleton<IQueryService, QueryService>();
            builder.Services.AddSingleton<IAppDbContextFactory, AppDbContextFactory>();
            
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