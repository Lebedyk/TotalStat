using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TotalStat
{
    class DatabaseContext : DbContext
    {
        DatabaseContext() : base("DefaultConnection")
        { }

        DbSet<Description> Descriptions { get; set; }
        DbSet<Screen> Screens { get; set; }
    }
}
