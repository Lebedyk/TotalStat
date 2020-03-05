using System.Data.Entity;

namespace TotalStat
{
    class ReportContext : DbContext
    {
        public ReportContext() : base ("DefaultConnection")
        { }
        public DbSet<Report> Reports { get; set; }
    }
}
