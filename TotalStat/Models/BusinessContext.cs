using System.Data.Entity;

namespace TotalStat
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("DefaultConnection")
        { }
        public DbSet<Business> Businesses { get; set; }

    }
}
