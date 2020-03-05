using System;

namespace TotalStat
{
    public class Business
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Biz { get; set; }

        public Business()
        {

        }
        public Business(string infoString, char splitter)
        {
            infoString = infoString.Replace("\r", "").Replace(",", "");
            string[] splitLines = infoString.Split(splitter);
            try
            {
                Ticker = splitLines[0];
                Biz = splitLines[1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
