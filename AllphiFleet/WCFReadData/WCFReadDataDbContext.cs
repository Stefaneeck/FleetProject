using System.Data.Entity;
using WCFReadEntities;

namespace WCFReadData
{
    public class WCFReadDataDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
    }
}
