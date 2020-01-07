using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class Description
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Country { get; set; }
        public double MarketCap { get; set; }
        public double ShortFloat { get; set; }
        public double AvarageVolume { get; set; }
        public int Id { get; set; }
    }
}
