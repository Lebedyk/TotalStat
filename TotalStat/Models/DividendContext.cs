using System.Data.Entity;

namespace TotalStat
{
    class DividendContext : DbContext
    {
        public DividendContext() : base("DefaultConnection")
        { }
        public DbSet<Dividend> Dividends { get; set; }
    }
}
