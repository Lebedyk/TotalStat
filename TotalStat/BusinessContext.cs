using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("DefaultConnection")
        { }
        public DbSet<Business> Businesses { get; set; }

    }
}
