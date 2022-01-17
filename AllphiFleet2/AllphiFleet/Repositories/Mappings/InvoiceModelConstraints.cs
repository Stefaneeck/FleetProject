/*
using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class InvoiceModelConstraints
    {
        public static void OnModelCreatingInvoice(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
               .HasKey(i => i.Id);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.ClientName)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.ClientName)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceDocumentPath)
                .IsRequired();
        }
    }
}
*/
