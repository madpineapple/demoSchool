using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using schoolManagerWebsite.Data;

[assembly: HostingStartup(typeof(schoolManagerWebsite.Areas.Identity.IdentityHostingStartup))]
namespace schoolManagerWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<schoolDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("schoolManagerWebsiteContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<schoolDbContext>();
            });
        }
    }
}