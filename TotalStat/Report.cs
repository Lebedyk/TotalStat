using System;

namespace TotalStat
{
    public class Report
    {
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string EarningTime { get; set; }

        public Report()
        {

        }
        public Report(string ticker, DateTime date, string earningTime)
        {
            try
            {
                ticker = ticker.Replace("\r", "");
                ticker = ticker.ToUpper();
                Ticker = ticker;
                Date = date;
                EarningTime = earningTime;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }        
    }
}
