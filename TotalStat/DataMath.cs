using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TotalStat
{
    public class DataForDataGrid
    {
        public DateTime Date { get; set; }
        public double FirstNitePercent { get; set; }
        public double SecondNitePercent { get; set; }
        public double DeltaNite { get; set; }
        public int FirstPremVol { get; set; }

        public DataForDataGrid(DateTime date, double firstnitepercent, double secondnitepercent, int premvol)
        {
            this.Date = date;
            this.FirstNitePercent = firstnitepercent;
            this.SecondNitePercent = secondnitepercent;
            this.DeltaNite = firstnitepercent - secondnitepercent;
            this.FirstPremVol = premvol;
        }
    }
    public class DataMath
    {
        private string FirstTicker { get; set; }
        private string SecondTicker { get; set; }
        public double Beta { get; private set; }
        public double HvBeta { get; private set; }
        public double Correlation { get; private set; }
        public int AvgPremVol { get; private set; }
        private List<List<Screen>> AllDatesScreens { get; set; }
        private List<Screen> SelectFirstStockScreens { get; set; } = new List<Screen>();
        private List<Screen> SelectSecondStockScreens { get; set; } = new List<Screen>();
        public List<DataForDataGrid> DataGrid { get; private set; } = new List<DataForDataGrid>();
        public DataMath()
        {

        }
        public DataMath(string firstticker, string secondticker, List<List<Screen>> alldatesscreens)
        {
            this.FirstTicker = firstticker;
            this.SecondTicker = secondticker;
            this.AllDatesScreens = alldatesscreens;
            SetSelectStockScreens();
            SetDataGrid();
            SetBetaHvBeta();
            SetCorrelation();
            SetAveragePremarketVolume();
        }
        private void SetSelectStockScreens()
        {
            if(AllDatesScreens != null)
            {
                foreach (List<Screen> onedate in AllDatesScreens)
                {
                    var temp1 = onedate.Where(p => p.Ticker == FirstTicker).FirstOrDefault();
                    var temp2 = onedate.Where(p => p.Ticker == SecondTicker).FirstOrDefault();
                    if ((temp1 != null) && (temp2 != null))
                    {
                        SelectFirstStockScreens.Add(temp1);
                        SelectSecondStockScreens.Add(temp2);
                    }
                    else if ((temp1 == null) && (temp2 != null))
                    {
                        SelectFirstStockScreens.Add(new Screen { Id = 0, Date = temp2.Date });
                        SelectSecondStockScreens.Add(temp2);
                    }
                    else if ((temp1 != null) && (temp2 == null))
                    {
                        SelectFirstStockScreens.Add(temp1);
                        SelectSecondStockScreens.Add(new Screen { Id = 0, Date = temp1.Date });
                    }
                    else
                    {
                        SelectFirstStockScreens.Add(new Screen { Id = 0, Date = onedate[0].Date });
                        SelectSecondStockScreens.Add(new Screen { Id = 0, Date = onedate[0].Date });
                    }
                }
            }                        
        }         
        private void SetBetaHvBeta()
        {
            double dirtyBeta;
            double clearBeta;
            double clearHvBeta;
            List<double> dirtyBetaList = new List<double>();
            List<double> clearBetaList = new List<double>();
            List<double> hvBetaList = new List<double>();
            List<double> clearHvBetaList = new List<double>();

            for (int i = 0; i < SelectFirstStockScreens.Count(); i++)
            {
                if (SelectFirstStockScreens[i].Id != 0 && SelectSecondStockScreens[i].Id != 0)
                {
                    if (((SelectFirstStockScreens[i].NitePercent > 0) && (SelectSecondStockScreens[i].NitePercent > 0)) ||
                        ((SelectFirstStockScreens[i].NitePercent < 0) && (SelectSecondStockScreens[i].NitePercent < 0)))
                    {
                        double temporaryBeta = SelectFirstStockScreens[i].NitePercent / SelectSecondStockScreens[i].NitePercent;
                        dirtyBetaList.Add(temporaryBeta);
                        if((SelectSecondStockScreens[i].NitePercent > 0.35) || (SelectSecondStockScreens[i].NitePercent < -0.35))
                        {
                            hvBetaList.Add(temporaryBeta);
                        }
                    }
                    else if ((SelectFirstStockScreens[i].NitePercent == 0) || (SelectSecondStockScreens[i].NitePercent == 0))
                    {
                        dirtyBetaList.Add(1);
                    }
                    else
                    {
                        dirtyBetaList.Add(0);
                    }
                }
            }            
            dirtyBeta = dirtyBetaList.Count()>0?dirtyBetaList.Average():0;
            clearBetaList = dirtyBetaList.Where(p => p < (dirtyBeta * 2.5)).ToList();
            clearBeta = clearBetaList.Count() > 0 ? clearBetaList.Average() : 0;
            clearHvBetaList = hvBetaList.Where(p => p < (clearBeta * 3)).ToList();
            clearHvBeta = clearHvBetaList.Count() > 0 ? clearHvBetaList.Average() : 0;
            HvBeta = clearHvBeta;
            Beta = clearBeta;
        }
        private void SetCorrelation()
        {
            int count = 0;
            for (int i = 0; i < SelectFirstStockScreens.Count(); i++)
            {
                if ((SelectFirstStockScreens[i].Id != 0) && (SelectSecondStockScreens[i].Id != 0))
                {
                    if (((SelectFirstStockScreens[i].NitePercent > 0) && (SelectSecondStockScreens[i].NitePercent > 0)) ||
                        ((SelectFirstStockScreens[i].NitePercent < 0) && (SelectSecondStockScreens[i].NitePercent < 0)))
                    {
                        count++;
                    }
                    else if ((SelectFirstStockScreens[i].NitePercent == 0) || (SelectSecondStockScreens[i].NitePercent == 0))
                    {
                        count++;
                    }
                }
            }
            if((SelectFirstStockScreens.Count()>0) && (count >0))
            {
                Correlation = (double)count / (double)SelectFirstStockScreens.Count();
            }
            else { Correlation = 0; }
        }
        private void SetAveragePremarketVolume()
        {
            AvgPremVol = SelectFirstStockScreens.Count() > 0 ? (int)SelectFirstStockScreens.Average(p => p.PremVolume) : 0;
        }
        private void SetDataGrid()
        {            
            DataGrid = SelectFirstStockScreens.Join(SelectSecondStockScreens, f => f.Date, s => s.Date,
                                              (f, s) => new DataForDataGrid(f.Date, f.NitePercent, s.NitePercent, f.PremVolume))
                                                .OrderByDescending(p => p.Date).ToList();           
        }        
    }
}
