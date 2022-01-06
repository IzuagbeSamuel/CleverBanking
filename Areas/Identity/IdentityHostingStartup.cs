using System;
using CleverBanking.Areas.Identity.Data;
using CleverBanking.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CleverBanking.Areas.Identity.IdentityHostingStartup))]
namespace CleverBanking.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CleverBankingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CleverBankingContextConnection")));

                services.AddDefaultIdentity<CleverBankingUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CleverBankingContext>();
            });
        }
    }
}