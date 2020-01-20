using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    /// 
    public partial class AppWindow : Window, INotifyPropertyChanged
    {
        private List<List<Screen>> database;
        private List<Sector> sectorbase;
        private List<Report> reportbase;
        private List<Dividend> dividendbase;
        private List<Description> descriptionbase;
        private List<Business> businessbase;
        
        private WorkWithData workdata;
        private ObservableCollection<Sector> firstsectorforview = new ObservableCollection<Sector>();
        private ObservableCollection<Sector> secondsectorforview = new ObservableCollection<Sector>();
        private ObservableCollection<Sector> thirdsectorforview = new ObservableCollection<Sector>();
        private static List<Report> actualreports = new List<Report>();
        private string reportforview;
        private string divforview;
        private string firststocktextboxstring;
        private string secondstocktextboxstring;
        private Description desc;

        public List<Sector> SectorBase
        {
            get { return sectorbase; }
            set { sectorbase = value; }
        }
        public List<Report> ReportBase
        {
            get { return reportbase; }
            set { reportbase = value; }
        }
        public List<Dividend> DividendBase
        {
            get { return dividendbase; }
            set { dividendbase = value; }
        }
        public List<Description> DescriptionBase
        {
            get { return descriptionbase; }
            set { descriptionbase = value; }
        }
        public List<Business> BusinessBase
        {
            get { return businessbase; }
            set { businessbase = value; }
        }
        public string ReportForView
        {
            get { return reportforview; }
            set
            {
                reportforview = value;
                OnPropertyChanged("ReportForView");
            }
        }
        public string DivForView
        {
            get { return divforview; }
            set 
            {
                divforview = value;
                OnPropertyChanged("DivForView");
            }
        }
        public string FirstStockTextBoxString
        {
            get { return firststocktextboxstring; }
            set
            {
                firststocktextboxstring = value;
                SetSectorsByLevels();
                SetReport();
                SetDiv();
                SetDesc();
                WorkData = new WorkWithData(FirstStockTextBoxString, SecondStockTextBoxString, database);
            }
        }
        public string SecondStockTextBoxString
        {
            get { return secondstocktextboxstring; }
            set
            {
                secondstocktextboxstring = value; 
                WorkData = new WorkWithData(FirstStockTextBoxString, SecondStockTextBoxString, database);
            }
        }
        public Description Desc
            {
            get { return desc; }
            set
            {
                desc = value;
                OnPropertyChanged("Desc");
            }
        }
        public WorkWithData WorkData
        {
            get { return workdata; }
            set 
            { 
                workdata = value;
                OnPropertyChanged("WorkData");
            }
        }
        public ObservableCollection<Sector> FirstSectorForView
        {
            get { return firstsectorforview; }
            set { firstsectorforview = value; }
        }
        public ObservableCollection<Sector> SecondSectorForView
        {
            get { return secondsectorforview; }
            set { secondsectorforview = value; }
        }
        public ObservableCollection<Sector> ThirdSectorForView
        {
            get { return thirdsectorforview; }
            set { thirdsectorforview = value; }
        }
        public static List<Report> ActualReports
        {
            get { return actualreports; }
            set { actualreports = value; }
        }

        public AppWindow()
        {            
            InitializeComponent();
            DataContext = this;
            this.Closed += AppWindow_Closed;            
            database = LoadScreens();
            SectorBase = LoadSectors();
            ReportBase = LoadReports();            
            DividendBase = LoadDividends();
            DescriptionBase = LoadDescriptions();
            BusinessBase = LoadBusinesses();
            FirstStockTextBoxString = "BAC";
            SecondStockTextBoxString = "SPY";
            SetSectorsByLevels();
            SetReport();
            SetDiv();
            SetDesc();
            ActualReports = GetActualReports();
            WorkData = new WorkWithData(FirstStockTextBoxString, SecondStockTextBoxString, database);            
        }
        private void AppWindow_Closed(object sender, EventArgs e)
        {            
            App.Current.MainWindow.Visibility = Visibility.Visible;
            AppConfiguration.SaveSizeAndGeometry();            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }        

        private List<List<Screen>> LoadScreens()
        {
            ScreenContext screenDb = new ScreenContext();
            List<List<Screen>> screensdata = new List<List<Screen>>();
            var first = screenDb.Screens.AsNoTracking().GroupBy(p => p.Date).Take(400).ToList();
            foreach(var second in first)
            {
                screensdata.Add(second.ToList());
            }
            return screensdata;
        }
        private List<Sector> LoadSectors()
        {
            List<Sector> sectorsdata = new List<Sector>();
            SectorContext sectorDb = new SectorContext();
            sectorsdata = sectorDb.Sectors.AsNoTracking().ToList();
            return sectorsdata;
        }
        private void SetSectorsByLevels()
        {            
            FirstSectorForView.Clear();
            SecondSectorForView.Clear();
            ThirdSectorForView.Clear();
            var first = SectorBase.Where(p => p.SectorLevel == 1).FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            var second = SectorBase.Where(p => p.SectorLevel == 2).FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            var third = SectorBase.Where(p => p.SectorLevel == 3).FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            if (first != null)
            {
                var firstsector = SectorBase.Where(p => p.SectorName == first.SectorName).Take(8);
                if(firstsector != null)
                {
                    foreach(Sector temp in firstsector)
                    {
                        FirstSectorForView.Add(temp);
                    }                   
                }
            }
            if (second != null)
            {
                var secondsector = SectorBase.Where(p => p.SectorName == second.SectorName).Take(8);
                if (secondsector != null)
                {
                    foreach (Sector temp in secondsector)
                    {
                        SecondSectorForView.Add(temp);
                    }
                }
            }
            if (third != null)
            {
                var thirdsector = SectorBase.Where(p => p.SectorName == third.SectorName).Take(8);
                if (thirdsector != null)
                {
                    foreach (Sector temp in thirdsector)
                    {
                        ThirdSectorForView.Add(temp);
                    }
                }
            }
        }
        private List<Report> LoadReports()
        {
            List<Report> reportslist = new List<Report>();
            ReportContext reportDb = new ReportContext();
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            DateTime beforeyesterday = today.AddDays(-2);
            DateTime tomorrow = today.AddDays(1);
            
            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                beforeyesterday = today.AddDays(-2);
                yesterday = today.AddDays(-1);
                tomorrow = today.AddDays(3);
            }
            else if(today.DayOfWeek == DayOfWeek.Monday)
            {
                beforeyesterday = today.AddDays(-4);
                yesterday = today.AddDays(-3);
                tomorrow = today.AddDays(1);
            }
            else if(today.DayOfWeek == DayOfWeek.Tuesday)
            {
                beforeyesterday = today.AddDays(-4);
                yesterday = today.AddDays(-1);
                tomorrow = today.AddDays(1);
            }

            var reportstoday = reportDb.Reports.Where(p => p.Date == today).ToList();
            var reportsyesterday = reportDb.Reports.Where(p => p.Date == yesterday).ToList();
            var reportsbeforeyesterday = reportDb.Reports.Where(p => p.Date == beforeyesterday).Where(p => p.EarningTime == "After Close").ToList();
            var reportstomorrow = reportDb.Reports.Where(p => p.Date == tomorrow).ToList();
            if(reportstoday != null)
            {
                reportslist.AddRange(reportstoday);
            }
            if (reportsyesterday != null)
            {
                reportslist.AddRange(reportsyesterday);
            }
            if (reportsbeforeyesterday != null)
            {
                reportslist.AddRange(reportsbeforeyesterday);
            }
            if (reportstomorrow != null)
            {
                reportslist.AddRange(reportstomorrow);
            }            

            return reportslist;
        }
        private void SetReport()
        {
            ReportForView = "";            
            string firstcharacter = "";
            string secondcharacter = "";
            Report temp = ReportBase.FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            DateTime beforeyesterday = today.AddDays(-2);
            DateTime tomorrow = today.AddDays(1);

            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                beforeyesterday = today.AddDays(-2);
                yesterday = today.AddDays(-1);
                tomorrow = today.AddDays(3);
            }
            else if (today.DayOfWeek == DayOfWeek.Monday)
            {
                beforeyesterday = today.AddDays(-4);
                yesterday = today.AddDays(-3);
                tomorrow = today.AddDays(1);
            }
            else if (today.DayOfWeek == DayOfWeek.Tuesday)
            {
                beforeyesterday = today.AddDays(-4);
                yesterday = today.AddDays(-1);
                tomorrow = today.AddDays(1);
            }
            if (temp != null)
            {                
                if (temp.EarningTime == "Before Open")
                {
                    secondcharacter = "BO";
                }
                else
                {
                    secondcharacter = "AC";
                }

                if (temp.Date == today)
                {
                    firstcharacter = "A";
                }
                else if(temp.Date == yesterday)
                {
                    firstcharacter = "Y";
                }
                else if(temp.Date == beforeyesterday)
                {
                    firstcharacter = "YY";
                }
                else if(temp.Date == tomorrow)
                {
                    firstcharacter = "T";
                }                
            }
            ReportForView = firstcharacter + secondcharacter;
        }
        private List<Report> GetActualReports()
        {
            List<Report> ActualReportList = new List<Report>();
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            DateTime beforeyesterday = today.AddDays(-2);
            DateTime tomorrow = today.AddDays(1);

            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                beforeyesterday = today.AddDays(-2);
                yesterday = today.AddDays(-1);
                tomorrow = today.AddDays(3);
            }
            else if (today.DayOfWeek == DayOfWeek.Monday)
            {
                beforeyesterday = today.AddDays(-4);
                yesterday = today.AddDays(-3);
                tomorrow = today.AddDays(1);
            }
            else if (today.DayOfWeek == DayOfWeek.Tuesday)
            {
                beforeyesterday = today.AddDays(-4);
                yesterday = today.AddDays(-1);
                tomorrow = today.AddDays(1);
            }
            var RepTodayBeforeOpen = ReportBase.Where(p=>p.Date == today).Where(p=>p.EarningTime == "Before Open").ToList();
            var RepYesterdayAfterClose = ReportBase.Where(p => p.Date == yesterday).Where(p => p.EarningTime == "After Close").ToList();
            if(RepTodayBeforeOpen.Count() > 0)
            {
                ActualReportList.AddRange(RepTodayBeforeOpen);
            }
            if(RepYesterdayAfterClose.Count>0)
            {
                ActualReportList.AddRange(RepYesterdayAfterClose);
            }
            return ActualReportList;
        }
        private List<Dividend> LoadDividends()
        {
            List<Dividend> dividends = new List<Dividend>();
            DividendContext divDb = new DividendContext();
            dividends = divDb.Dividends.AsNoTracking().Where(p => p.Date == DateTime.Today).ToList();

            return dividends;
        }
        private void SetDiv()
        {
            DivForView = "";
            Dividend temp = DividendBase.Where(p => p.Ticker == FirstStockTextBoxString).FirstOrDefault();            
            if(temp!=null)
            {
                DivForView = temp.Sum.ToString();
            }
        }
        private List<Description> LoadDescriptions()
        {
            List<Description> descriptions = new List<Description>();
            DescriptionContext descDb = new DescriptionContext();
            descriptions = descDb.Descriptions.AsNoTracking().ToList();
 
            return descriptions;
        }        
        private void SetDesc()
        {            
            Desc = DescriptionBase.FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
        }
        private List<Business> LoadBusinesses()
        {
            List<Business> businesses = new List<Business>();
            BusinessContext busDb = new BusinessContext();
            businesses = busDb.Businesses.AsNoTracking().ToList();
            return businesses;
        }

        private async void Report_AddFromApp_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(FirstStockTextBoxString != "")
            {
                ReportContext db = new ReportContext();
                Report report = new Report { Ticker = FirstStockTextBoxString, Date = DateTime.Today, EarningTime = "Before Open" };
                db.Reports.Add(report);
                ReportBase.Add(report);
                SetReport();
                await db.SaveChangesAsync();
            }            
        }
        private void Business_Show_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            var temp = businessbase.FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            if(temp != null)
            {
                MessageBox.Show(temp.Biz, temp.Ticker);
            }
        }                
    }
}
