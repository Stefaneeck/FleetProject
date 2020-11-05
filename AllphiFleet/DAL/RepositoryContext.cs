using AllphiFleet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Chauffeur> Chauffeurs { get; set; }
        //public DbSet<Account> Accounts { get; set; }
    }
}
