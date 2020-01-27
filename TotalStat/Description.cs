using System;

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

        public Description()
        {

        }
        public Description(string infoString, char splitter)
        {
            infoString = infoString.Replace("\r", "").Replace(",", "");
            string[] splitLines = infoString.Split(splitter);
            try
            {
                Ticker = splitLines[0];
                CompanyName = splitLines[1];
                Sector = splitLines[2];
                Industry = splitLines[3];
                Country = splitLines[4];
                MarketCap = Double.TryParse(splitLines[5], out double marketCap) ? marketCap : 0;
                ShortFloat = Double.TryParse(splitLines[5], out double shortFloat) ? shortFloat : 0;
                AvarageVolume = Double.TryParse(splitLines[5], out double avarageVolume) ? avarageVolume : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
