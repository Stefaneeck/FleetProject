using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class InsuranceCompanyModelConstraints
    {
        public static void OnModelCreatingInsuranceCompany(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceCompany>()
               .HasKey(i => i.Id);

            modelBuilder.Entity<InsuranceCompany>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<InsuranceCompany>()
                .Property(i => i.RefNrInsuranceCompany)
                .IsRequired();
        }
    }
}
