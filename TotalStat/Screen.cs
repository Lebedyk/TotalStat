using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class Screen
    {
        public string Ticker { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Nite { get; set; }
        public double NitePercent { get; set; }
        public int ImbNY { get; set; }
        public int ImbEx { get; set; }
        public int PremVolume { get; set; }
        public DateTime Date { get; set; }
    }
}
