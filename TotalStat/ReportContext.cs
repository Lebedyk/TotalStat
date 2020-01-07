using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    class ReportContext : DbContext
    {
        public ReportContext() : base ("DefaultConnection")
        { }
        public DbSet<Report> Reports { get; set; }
    }
}
