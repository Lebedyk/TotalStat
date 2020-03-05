using System.Data.Entity;

namespace TotalStat
{
    class SectorContext : DbContext
    {
        public SectorContext() : base("DefaultConnection")
        { }
        public DbSet<Sector> Sectors { get; set; }
    }
}
