using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class InvoiceModelConstraints
    {
        public static void OnModelCreatingInvoice(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
               .HasKey(f => f.Id);

            modelBuilder.Entity<Invoice>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Invoice>()
                .Property(f => f.ClientName)
                .IsRequired();
        }
    }
}
