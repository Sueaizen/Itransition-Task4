using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication15.Areas.Identity.Data;
using WebApplication15.Data;

[assembly: HostingStartup(typeof(WebApplication15.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication15.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplication15Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApplication15ContextConnection")));

                services.AddDefaultIdentity<WebApplication15User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<WebApplication15Context>();
            });
        }
    }
}