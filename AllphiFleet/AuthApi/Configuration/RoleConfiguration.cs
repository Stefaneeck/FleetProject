using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Configuration
{
    //todo move to seed data
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private ApplicationDbContext _context;

        public RoleConfiguration()
        {

        }
        public RoleConfiguration(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Visitor",
                NormalizedName = "VISITOR"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
        }
    }
}
