using System.Data.Entity;

namespace TotalStat
{
    public class ScreenContext : DbContext
    {
        public ScreenContext() : base("DefaultConnection")
        { }
        public DbSet<Screen> Screens { get; set; }
    }
}
