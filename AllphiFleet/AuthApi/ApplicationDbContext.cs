using AuthApi.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi
{
    public class ApplicationDbContext : IdentityDbContext
    {
        /* Create a DbContext that inherits ASP.NET Identity’s IdentityDbContext and override the constructor to use a non-generic version of DbContextOptions.
         * This is because IdentityDbContext only has a constructor accepting the generic DbContextOptions which, 
         * when you are registering multiple DbContexts, results in an InvalidOperationException.
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
