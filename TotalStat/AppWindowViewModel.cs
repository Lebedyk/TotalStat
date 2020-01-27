using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace TotalStat
{
    class AppWindowViewModel : INotifyPropertyChanged
    {
        private List<List<Screen>> _dataBase;
        private DataMath _workData;
        private string _reportForView;
        private string _divForView;
        private string _firstStockTextBoxString;
        private string _secondStockTextBoxString;
        private Description _desc;

        public DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer timerRecheck = new DispatcherTimer();

        private string _linkWindowText;
        IntPtr Hwnd;

        public List<Sector> SectorBase { get; set; }
        public List<Report> ReportBase { get; set; }
        public List<Dividend> DividendBase { get; set; }
        public List<Description> DescriptionBase { get; set; }
        public List<Business> BusinessBase { get; set; }
        public string ReportForView
        {
            get { return _reportForView; }
            set
            {
                _reportForView = value;
                OnPropertyChanged("ReportForView");
            }
        }
        public string DivForView
        {
            get { return _divForView; }
            set
            {
                _divForView = value;
                OnPropertyChanged("DivForView");
            }
        }
        public string FirstStockTextBoxString
        {
            get { return _firstStockTextBoxString; }
            set
            {
                _firstStockTextBoxString = value;
                SetSectorsByLevels();
                SetReport();
                SetDiv();
                SetDesc();
                WorkData = new DataMath(FirstStockTextBoxString, SecondStockTextBoxString, _dataBase);
                OnPropertyChanged("FirstStockTextBoxString");
            }
        }
        public string SecondStockTextBoxString
        {
            get { return _secondStockTextBoxString; }
            set
            {
                _secondStockTextBoxString = value;
                WorkData = new DataMath(FirstStockTextBoxString, SecondStockTextBoxString, _dataBase);
            }
        }
        public Description Desc
        {
            get { return _desc; }
            set
            {
                _desc = value;
                OnPropertyChanged("Desc");
            }
        }
        public DataMath WorkData
        {
            get { return _workData; }
            set
            {
                _workData = value;
                OnPropertyChanged("WorkData");
            }
        }
        public ObservableCollection<Sector> FirstSectorForView { get; set; } = new ObservableCollection<Sector>();
        public ObservableCollection<Sector> SecondSectorForView { get; set; } = new ObservableCollection<Sector>();
        public ObservableCollection<Sector> ThirdSectorForView { get; set; } = new ObservableCollection<Sector>();
        private string _firstSectorName;
        public string FirstSectorName 
        { 
            get { return _firstSectorName; }
            set
            {
                _firstSectorName = value;
                OnPropertyChanged("FirstSectorName");
            }
        }
        private string _secondSectorName;
        public string SecondSectorName
        {
            get { return _secondSectorName; }
            set
            {
                _secondSectorName = value;
                OnPropertyChanged("SecondSectorName");
            }
        }
        private string _thirdSectorName;
        public string ThirdSectorName
        {
            get { return _thirdSectorName; }
            set
            {
                _thirdSectorName = value;
                OnPropertyChanged("ThirdSectorName");
            }
        }
        public static List<Report> ActualReports { get; set; } = new List<Report>();

        private DBManager _DBManager = new DBManager();
        public AppWindowViewModel()
        {
            _dataBase = LoadScreens();
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
            WorkData = new DataMath(FirstStockTextBoxString, SecondStockTextBoxString, _dataBase);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //ASYNCCCCCC
        private List<List<Screen>> LoadScreens()
        {
            ScreenContext screenDb = new ScreenContext();
            List<List<Screen>> screensdata = new List<List<Screen>>();
            var first = screenDb.Screens.AsNoTracking().GroupBy(p => p.Date).Take(400).ToList();
            foreach (var second in first)
            {
                screensdata.Add(second.ToList());
            }
            return screensdata;
        }
        private List<Sector> LoadSectors()
        {
            SectorContext sectorDb = new SectorContext();
            return sectorDb.Sectors.AsNoTracking().ToList();
        }
        private void SetSectorsByLevels()
        {
            FirstSectorForView.Clear();
            SecondSectorForView.Clear();
            ThirdSectorForView.Clear();
            FirstSectorName = null;
            SecondSectorName = null;
            ThirdSectorName = null;

            //сделать отдельные парсеры для каждого кейса как DayShift
            var first = SectorBase.Where(p => p.SectorLevel == 1).FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            var second = SectorBase.Where(p => p.SectorLevel == 2).FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            var third = SectorBase.Where(p => p.SectorLevel == 3).FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
            if (first != null)
            {
                var firstsector = SectorBase.Where(p => p.SectorName == first.SectorName).Take(8);
                if (firstsector != null)
                {
                    foreach (Sector temp in firstsector)
                    {
                        FirstSectorForView.Add(temp);
                    }
                    FirstSectorName = FirstSectorForView[0].SectorName;
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
                    SecondSectorName = SecondSectorForView[0].SectorName;
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
                    ThirdSectorName = ThirdSectorForView[0].SectorName;
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

            var reportstoday = reportDb.Reports.Where(p => p.Date == today).ToList();
            var reportsyesterday = reportDb.Reports.Where(p => p.Date == yesterday).ToList();
            var reportsbeforeyesterday = reportDb.Reports.Where(p => p.Date == beforeyesterday).Where(p => p.EarningTime == "After Close").ToList();
            var reportstomorrow = reportDb.Reports.Where(p => p.Date == tomorrow).ToList();
            if (reportstoday != null)
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
                else if (temp.Date == yesterday)
                {
                    firstcharacter = "Y";
                }
                else if (temp.Date == beforeyesterday)
                {
                    firstcharacter = "YY";
                }
                else if (temp.Date == tomorrow)
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
            var RepTodayBeforeOpen = ReportBase.Where(p => p.Date == today).Where(p => p.EarningTime == "Before Open").ToList();
            var RepYesterdayAfterClose = ReportBase.Where(p => p.Date == yesterday).Where(p => p.EarningTime == "After Close").ToList();
            if (RepTodayBeforeOpen.Count() > 0)
            {
                ActualReportList.AddRange(RepTodayBeforeOpen);
            }
            if (RepYesterdayAfterClose.Count > 0)
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
            if (temp != null)
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

        private WindowCommand _reportAddFromAppCommand;
        public WindowCommand ReportAddFromAppCommand
        {
            get
            {
                return _reportAddFromAppCommand ??
                    (_reportAddFromAppCommand = new WindowCommand(obj =>
                    {
                        if (FirstStockTextBoxString != string.Empty)
                        {
                            Report report = new Report(FirstStockTextBoxString, DateTime.Today, Localize.ReportTimeBO);
                            _DBManager.ReportContextAdd(report);
                            SetReport();
                        }
                    }));
            }
        }

        private WindowCommand _businessShowCommand;
        public WindowCommand BusinessShowCommand
        {
            get
            {
                return _businessShowCommand ??
                    (_businessShowCommand = new WindowCommand(obj =>
                    {
                        var temp = BusinessBase.FirstOrDefault(p => p.Ticker == FirstStockTextBoxString);
                        if (temp != null)
                        {
                            MessageBox.Show(temp.Biz, temp.Ticker);
                        }
                    }));
            }
        }

        private WindowCommand _linkStart;
        public WindowCommand LinkStart
        {
            get
            {
                return _linkStart ??
                    (_linkStart = new WindowCommand(obj =>
                    {                        
                        timer.Tick += new EventHandler(timer_TickLink);
                        timer.Interval = new TimeSpan(0, 0, 3);
                        timer.Start();                        
                    }));
            }
        }
        
        private void timer_TickLink(object sender, EventArgs e)
        {
            Hwnd = Link.GetHwnd();
            _linkWindowText = Link.GetText(Hwnd);
            FirstStockTextBoxString = Link.GetTicker(_linkWindowText);
            timer.Stop();

            timerRecheck.Tick += new EventHandler(timer_Tick_Link_Rechecked);
            timerRecheck.Interval = new TimeSpan(0, 0, 1);
            timerRecheck.Start();
        }
        private void timer_Tick_Link_Rechecked(object sender, EventArgs e)
        {
            if (_linkWindowText != Link.GetText(Hwnd))
            {
                _linkWindowText = Link.GetText(Hwnd);
                FirstStockTextBoxString = Link.GetTicker(_linkWindowText);
            }
        }
    }
}
