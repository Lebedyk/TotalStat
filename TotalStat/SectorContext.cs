using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    class SectorContext : DbContext
    {
        public SectorContext() : base("DefaultConnection")
        { }
        public DbSet<Sector> Sectors { get; set; }
    }
}
