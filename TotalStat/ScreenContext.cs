using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class ScreenContext : DbContext
    {
        public ScreenContext() : base("DefaultConnection")
        { }
        public DbSet<Screen> Screens { get; set; }
    }
}
