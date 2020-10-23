using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication15.Areas.Identity.Data;

namespace WebApplication15.Data
{
    public class WebApplication15Context : IdentityDbContext<WebApplication15User>
    {
        public WebApplication15Context(DbContextOptions<WebApplication15Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication15User> WebApplication15User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
