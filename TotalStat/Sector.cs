using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class Sector
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public double MarketCap { get; set; }
        public string SectorName { get; set; }
        public int SectorLevel { get; set; }
    }
}
