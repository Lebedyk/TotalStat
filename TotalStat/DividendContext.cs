using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    class DividendContext : DbContext
    {
        public DividendContext() : base("DefaultConnection")
        { }

        public DbSet<Dividend> Dividends { get; set; }
    }
}
