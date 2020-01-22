using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TotalStat
{
    public class DataforDataGrid
    {
        public DateTime Date { get; set; }
        public double FirstNitePercent { get; set; }
        public double SecondNitePercent { get; set; }
        public double DeltaNite { get; set; }
        public int FirstPremVol { get; set; }
    }
    public class WorkWithData
    {
        private string firstticker;
        private string secondticker;
        private double beta;
        private double hvbeta;
        private double correlation;
        private int avgpremvol;
        private List<List<Screen>> alldatesscreens;
        private ObservableCollection<Screen> selectfirststockscreens = new ObservableCollection<Screen>();
        private ObservableCollection<Screen> selectsecondstockscreens = new ObservableCollection<Screen>();
        private List<DataforDataGrid> datagrid = new List<DataforDataGrid>();        

        public string FirstTicker 
        {
            get { return firstticker; }
            set { firstticker = value; }
        }
        public string SecondTicker
        {
            get { return secondticker; }
            set { secondticker = value; }
        }
        public double Beta
        {
            get { return beta; }
            set { beta = value; }
        }
        public double HvBeta
        {
            get { return hvbeta; }
            set { hvbeta = value; }
        }
        public double Correlation
        {
            get { return correlation; }
            set { correlation = value; }
        }
        public int AvgPremVol
        {
            get { return avgpremvol; }
            set { avgpremvol = value; }
        }
        public List<List<Screen>> AllDatesScreens
        {
            get { return alldatesscreens; }
            set { alldatesscreens = value; }
        }
        public ObservableCollection<Screen> SelectFirstStockScreens
        {
            get { return selectfirststockscreens; }
            set { selectfirststockscreens = value; }
        }
        public ObservableCollection<Screen> SelectSecondStockScreens
        {
            get { return selectsecondstockscreens; }
            set { selectsecondstockscreens = value; }
        }
        public List<DataforDataGrid> DataGrid
        {
            get { return datagrid; }
            set { datagrid = value;
                    }
        }
        public WorkWithData(string firstticker, string secondticker,  List<List<Screen>> alldatesscreens)
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
            foreach(List<Screen> onedate in AllDatesScreens)
            {                
                var temp1 = onedate.Where(p => p.Ticker == FirstTicker).FirstOrDefault();
                var temp2 = onedate.Where(p => p.Ticker == SecondTicker).FirstOrDefault();
                if ((temp1 != null) && (temp2 != null))
                {
                    SelectFirstStockScreens.Add(temp1);
                    SelectSecondStockScreens.Add(temp2);                    
                }
                else if((temp1 == null) && (temp2 != null))
                {
                    SelectFirstStockScreens.Add(new Screen { Id = 0, Date = temp2.Date });
                    SelectSecondStockScreens.Add(temp2);
                }
                else if((temp1 != null) && (temp2 == null))
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
        private void SetDataGrid()
        {
            DataGrid = SelectFirstStockScreens.Join(SelectSecondStockScreens, f => f.Date, s => s.Date,
                                                    (f, s) => new DataforDataGrid
                                                    {
                                                        Date = f.Date,
                                                        FirstNitePercent = f.NitePercent,
                                                        SecondNitePercent = s.NitePercent,
                                                        DeltaNite = (f.NitePercent - s.NitePercent),
                                                        FirstPremVol = f.PremVolume
                                                    }).ToList();
            DataGrid.Reverse();
        }
        private void SetBetaHvBeta()
        {
            double dirtybeta;
            double clearbeta;
            double clearhvbeta;
            List<double> dirtybetalist = new List<double>();
            List<double> clearbetalist = new List<double>();
            List<double> hvbetalist = new List<double>();
            List<double> clearhvbetalist = new List<double>();

            for (int i = 0; i < SelectFirstStockScreens.Count(); i++)
            {
                if(SelectFirstStockScreens[i].Id != 0 && SelectSecondStockScreens[i].Id != 0)
                {
                    if(((SelectFirstStockScreens[i].NitePercent > 0) && (SelectSecondStockScreens[i].NitePercent > 0)) ||
                        ((SelectFirstStockScreens[i].NitePercent < 0) && (SelectSecondStockScreens[i].NitePercent < 0)))
                    {
                        double temporarybeta = SelectFirstStockScreens[i].NitePercent / SelectSecondStockScreens[i].NitePercent;
                        dirtybetalist.Add(temporarybeta);
                        if((SelectSecondStockScreens[i].NitePercent > 0.35) || (SelectSecondStockScreens[i].NitePercent < -0.35))
                        {
                            hvbetalist.Add(temporarybeta);
                        }
                    }
                    else if((SelectFirstStockScreens[i].NitePercent == 0) || (SelectSecondStockScreens[i].NitePercent == 0))
                    {
                        dirtybetalist.Add(1);
                    }
                }
            }
            
            dirtybeta = dirtybetalist.Count()>0?dirtybetalist.Average():0;
            clearbetalist = dirtybetalist.Where(p => p < (dirtybeta * 2.5)).ToList();
            clearbeta = clearbetalist.Count() > 0 ? clearbetalist.Average() : 0;
            clearhvbetalist = hvbetalist.Where(p => p < (clearbeta * 3)).ToList();
            clearhvbeta = clearhvbetalist.Count() > 0 ? clearhvbetalist.Average() : 0;
            HvBeta = clearhvbeta;
            Beta = clearbeta;
        }
        private void SetCorrelation()
        {
            int count = 0;
            for (int i = 0; i < SelectFirstStockScreens.Count(); i++)
            {
                if (SelectFirstStockScreens[i].Id != 0 && SelectSecondStockScreens[i].Id != 0)
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
                Correlation = SelectFirstStockScreens.Count() / count;
            }
            else { Correlation = 0; }
        }
        private void SetAveragePremarketVolume()
        {
            if(SelectFirstStockScreens.Count() > 0)
            {
                AvgPremVol = (int)SelectFirstStockScreens.Average(p => p.PremVolume);
            }
            else { AvgPremVol = 0; }
        }
    }
}
