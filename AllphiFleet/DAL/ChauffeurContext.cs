using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ChauffeurContext : DbContext
    {
        public ChauffeurContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AllphiFleet.Models.Chauffeur> Chauffeurs { get; set; }
        //public DbSet<Account> Accounts { get; set; }
    }
}
