using System;

namespace TotalStat
{
    public class Dividend
    {
        public string Ticker { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public Dividend()
        {

        }
        public Dividend(string infoString, char splitter, DateTime date)
        {
            infoString = infoString.Replace("\r", "").Replace(",", "");
            string[] splitArr = infoString.Split(splitter);
            try
            {
                Ticker = splitArr[0];
                Sum = double.TryParse(splitArr[1], out double sum) ? sum : 0;
                Date = date;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
