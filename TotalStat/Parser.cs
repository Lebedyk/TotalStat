using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class Parser
    {
        public DateTime ParceStringToDate(string dateLine)
        {
            try
            {
                string[] dateArr;
                dateArr = dateLine.Split('.');                
                DateTime date = new DateTime(Int32.Parse(dateArr[0]), Int32.Parse(dateArr[1]), Int32.Parse(dateArr[2]));
                return date;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DateTime ParcePathToDate(string pathLine)
        {
            DateTime date = new DateTime();
            try
            {                
                int index = pathLine.LastIndexOf("\\");
                string dateString = pathLine.Substring(index + 1);
                date = ParceStringToDate(dateString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return date;
        }

        public List<Sector> SectorParce(string fullsector, int sectorLevel)
        {
            List<Sector> sector = new List<Sector>();
            string[] splitLine = fullsector.Split(Localize.splitLines);
            try
            {
                foreach (string line in splitLine)
                {
                    sector.Add(new Sector(line, Localize.splitSpace, sectorLevel));
                }
            }
            catch (Exception ex)
            {
                sector.Clear();
                throw ex;
            }

            return sector;
        }
    }
}
