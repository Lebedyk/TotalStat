using System.Data.Entity;

namespace TotalStat
{
    public class DescriptionContext : DbContext
    {
        public DescriptionContext() : base("DefaultConnection")
        { }
        public DbSet<Description> Descriptions { get; set; }
    }
}
