using System;

namespace TotalStat
{
    public partial class Screen
    {
        public string Ticker { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Nite { get; set; }
        public double NitePercent { get; set; }
        public int ImbNY { get; set; }
        public int ImbEX { get; set; }
        public int PremVolume { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public Screen()
        { 

        }
       
        public Screen(string infoString, char splitter)
        {
            string split = infoString.Replace("\r", "").Replace(",", "");
            string[] splitArr = split.Split(splitter);
            try
            {
                Open = double.TryParse(splitArr[1], out double open) ? open : 0;
                Close = double.TryParse(splitArr[2], out double close) ? close : 0;
                Nite = double.TryParse(splitArr[3], out double nite) ? nite : 0;
                NitePercent = double.TryParse(splitArr[4], out double nitePerc) ? nitePerc : 0;
                ImbNY = Int32.TryParse(splitArr[5], out int imbNY) ? imbNY : 0;
                ImbEX = Int32.TryParse(splitArr[6], out int imbEX) ? imbEX : 0;
                PremVolume = Int32.TryParse(splitArr[7], out int premVolume) ? premVolume : 0;
                Date = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Screen(string newsplit, char splitter, DateTime date) : this(newsplit, splitter)
        {
            Date = date;
        }

    }
}
