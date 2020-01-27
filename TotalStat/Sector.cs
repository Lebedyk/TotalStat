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

        public Sector()
        {

        }
        public Sector(string lineInfo, char splitter, int sectorLevel)
        {
            lineInfo = lineInfo.Replace("\r", "");
            string[] splitSpace = lineInfo.Split(Localize.splitSpace);
            string sectorName = String.Join(" ", splitSpace, 2, (splitSpace.Length - 2));
            try
            {
                Ticker = splitSpace[0];
                MarketCap = Double.TryParse(splitSpace[1], out double marketCap) ? marketCap : 0;
                SectorName = sectorName;
                SectorLevel = sectorLevel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
