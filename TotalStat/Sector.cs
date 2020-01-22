using System;

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
