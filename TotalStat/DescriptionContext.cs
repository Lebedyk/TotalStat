using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class DescriptionContext : DbContext
    {
        public DescriptionContext() : base("DefaultConnection")
        { }
        public DbSet<Description> Descriptions { get; set; }
    }
}
