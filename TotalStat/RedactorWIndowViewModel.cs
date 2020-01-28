using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static TotalStat.RedactorWindow;

namespace TotalStat
{
    class RedactorWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private FileManager _fileManager = new FileManager();
        private Parser _Parser = new Parser();
        private DBManager _DBManager = new DBManager();
        private DayShiftValidator _DayShiftValidator = new DayShiftValidator();
        private FileDialogSelect _selectedFile;
        public FileDialogSelect SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                _selectedFile = value;
                OnPropertyChanged("SelectedFile");
            }
        }

        private string _finvizFilePath;
        public string FinvizFilePath
        {
            get { return _finvizFilePath; }
            set
            {
                _finvizFilePath = value;
                OnPropertyChanged("FinvizFilePath");
            }
        }
        private string _aboutFilePath;
        public string AboutFilePath
        {
            get { return _aboutFilePath; }
            set
            {
                _aboutFilePath = value;
                OnPropertyChanged("AboutFilePath");
            }
        }
        private string _reportFilePath;
        public string ReportFilePath
        {
            get { return _reportFilePath; }
            set
            {
                _reportFilePath = value;
                OnPropertyChanged("ReportFilePath");
            }
        }
        private string _dividendFilePath;        
        public string DividendFilePath
        {
            get { return _dividendFilePath; }
            set
            {
                _dividendFilePath = value;
                OnPropertyChanged("DividendFilePath");
            }
        }
        public ObservableCollection<FileDialogSelect> ChoosenFiles { get; set; } = new ObservableCollection<FileDialogSelect>();

        private string _lastUpdate;
        public string LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                _lastUpdate = value;
                OnPropertyChanged("LastUpdate");
            }
        }

        private bool _dataButtonsIsEnable = true;
        public bool DataButtonsIsEnable
        {
            get { return _dataButtonsIsEnable; }
            set
            {
                _dataButtonsIsEnable = value;
                OnPropertyChanged("ButtonIsEnable");
            }
        }
        private bool _infoButtonsIsEnable = true;
        public bool InfoButtonsIsEnable
        {
            get { return _infoButtonsIsEnable; }
            set
            {
                _infoButtonsIsEnable = value;
                OnPropertyChanged("InfoButtonsIsEnable");
            }
        }
        private bool _reportButtonsIsEnable = true;
        public bool ReportButtonsIsEnable
        {
            get { return _reportButtonsIsEnable; }
            set
            {
                _reportButtonsIsEnable = value;
                OnPropertyChanged("ReportButtonsIsEnable");
            }
        }
        private bool _dividendButtonsIsEnable = true;
        public bool DividendButtonIsEnable
        {
            get { return _dividendButtonsIsEnable; }
            set
            {
                _dividendButtonsIsEnable = value;
                OnPropertyChanged("DividendButtonIsEnable");
            }
        }

        private string _statusBar;
        public string StatusBar
        {
            get { return _statusBar; }
            set
            {
                _statusBar = value;
                OnPropertyChanged("StatusBar");
            }
        }
        private string _dataDeleteDateDay;
        public string DataDeleteDateDay
        {
            get { return _dataDeleteDateDay; }
            set
            {
                _dataDeleteDateDay = value;
                OnPropertyChanged("DataDeleteDateDay");
            }
        }
        private string _dataDeleteDateMonth;
        public string DataDeleteDateMonth
        {
            get { return _dataDeleteDateMonth; }
            set
            {
                _dataDeleteDateMonth = value;
                OnPropertyChanged("DataDeleteDateMonth");
            }
        }
        private string _dataDeleteDateYear;
        public string DataDeleteDateYear
        {
            get { return _dataDeleteDateYear; }
            set
            {
                _dataDeleteDateYear = value;
                OnPropertyChanged("DataDeleteDateYear");
            }
        }
        
        private string _reportDeleteDateDay;
        public string ReportDeleteDateDay
        {
            get { return _reportDeleteDateDay; }
            set
            {
                _reportDeleteDateDay = value;
                OnPropertyChanged("ReportDeleteDateDay");
            }
        }
        private string _reportDeleteDateMonth;
        public string ReportDeleteDateMonth
        {
            get { return _reportDeleteDateMonth; }
            set
            {
                _reportDeleteDateMonth = value;
                OnPropertyChanged("ReportDeleteDateMonth");
            }
        }
        private string _reportDeleteDateYear;
        public string ReportDeleteDateYear
        {
            get { return _reportDeleteDateYear; }
            set
            {
                _reportDeleteDateYear = value;
                OnPropertyChanged("ReportDeleteDateYear");
            }
        }

        private string _dividendDeleteDateDay;
        public string DividendDeleteDateDay
        {
            get { return _dividendDeleteDateDay; }
            set
            {
                _dividendDeleteDateDay = value;
                OnPropertyChanged("DividendDeleteDateDay");
            }
        }
        private string _dividendDeleteDateMonth;
        public string DividendDeleteDateMonth
        {
            get { return _dividendDeleteDateMonth; }
            set
            {
                _dividendDeleteDateMonth = value;
                OnPropertyChanged("DividendDeleteDateMonth");
            }
        }
        private string _dividendDeleteDateYear;
        public string DividendDeleteDateYear
        {
            get { return _dividendDeleteDateYear; }
            set
            {
                _dividendDeleteDateYear = value;
                OnPropertyChanged("DividendDeleteDateYear");
            }
        }

        private string _dataAddDataTextBox;
        public string DataAddDataTextBox
        {
            get { return _dataAddDataTextBox; }
            set
            {
                _dataAddDataTextBox = value;
                OnPropertyChanged("_dataAddDataTextBox");
            }
        }
        private string _sectorAddSectorTextBox;
        public string SectorAddSectorTextBox
        {
            get { return _sectorAddSectorTextBox; }
            set
            {
                _sectorAddSectorTextBox = value;
                OnPropertyChanged("SectorAddSectorTextBox");
            }
        }
        private string _reportAddReportTextBox;
        public string ReportAddReportTextBox
        {
            get { return _reportAddReportTextBox; }
            set
            {
                _reportAddReportTextBox = value;
                OnPropertyChanged("ReportAddReportTextBox");
            }
        }
        private string _dividendAddDivTextBox;
        public string DividendAddDivTextBox
        {
            get { return _dividendAddDivTextBox; }
            set
            {
                _dividendAddDivTextBox = value;
                OnPropertyChanged("DividendAddDivTextBox");
            }
        }


        public RedactorWindowViewModel()
        {
            GetDataLastRefreshDate();



        }

        private WindowCommand _dataFileDialogCommand;
        public WindowCommand DataFileDialogCommand
        {
            get
            {
                return _dataFileDialogCommand ??
                    (_dataFileDialogCommand = new WindowCommand(obj =>
                   {
                       var list = _fileManager.FileDialogMulti(Localize.txtFilter);
                       if (list != null)
                       {
                           ChoosenFiles.Clear();
                           foreach (var temp in list)
                           {
                               ChoosenFiles.Add(temp);
                           }
                       }
                   }));
            }
        }

        private WindowCommand _dataRemoveCommand;
        public WindowCommand DataRemoveCommand
        {
            get
            {
                return _dataRemoveCommand ??
                    (_dataRemoveCommand = new WindowCommand(obj =>
                    {
                        ChoosenFiles.Remove(SelectedFile);
                    }));
            }
        }

        private WindowCommand _dataRefreshCommand;
        public WindowCommand DataRefreshCommand
        {
            get
            {
                return _dataRefreshCommand ??
                    (_dataRefreshCommand = new WindowCommand(async obj =>
                    {
                        _dataButtonsIsEnable = false;
                        foreach (FileDialogSelect fileDialog in ChoosenFiles)
                        {
                            ScreenContext db = new ScreenContext();
                            string fileText = null;
                            StreamReader file = null;
                            DateTime fileDate = new DateTime();
                            bool errorInput = false;
                            bool selectFile = false;
                            int lineError = 1;
                            List<Screen> addScreenToTable = new List<Screen>();
                            try
                            {
                                file = new StreamReader(fileDialog.Path);
                                fileDate = _Parser.ParceStringToDate(fileDialog.Name);
                                selectFile = true;
                                var dates = db.Screens.FirstOrDefault(p => p.Date == fileDate);
                                if (dates != null)
                                {
                                    errorInput = true;
                                    MessageBox.Show("Дата: " + fileDate + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                                }
                                else
                                {
                                    StatusBar = "Идет добавление " + fileDate.Date.ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                errorInput = true;
                                MessageBox.Show("Ошибка! \nНеправильный путь или имя файла: " + fileDialog.Path, ex.Message);
                            }
                            if (selectFile && !errorInput)
                            {
                                try
                                {
                                    fileText = await file.ReadToEndAsync();
                                    file.Close();
                                    fileText = fileText.Replace(",", "").Replace("\r", "");
                                    string[] splitLines = fileText.Split('\n');
                                    foreach (string temp in splitLines)
                                    {
                                        if (temp != string.Empty)
                                        {
                                            addScreenToTable.Add(new Screen(temp, Localize.splitTabulation));
                                        }
                                        lineError++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errorInput = true;
                                    MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                                    "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                                }
                                if (!errorInput)
                                {
                                    try
                                    {
                                        _DBManager.ScreenContextAdd(addScreenToTable);
                                    }
                                    catch (Exception ex)
                                    {
                                        errorInput = true;
                                        MessageBox.Show("Ошибка загрузки даты за " + fileDate + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                                    }
                                }
                            }
                        }
                        GetDataLastRefreshDate();
                        StatusBar = "Обновление завершено!";
                        _dataButtonsIsEnable = true;
                    }));
            }
        }

        private WindowCommand _dataDeleteDateCommand;
        public WindowCommand DataDeleteDateCommand
        {
            get
            {
                return _dataDeleteDateCommand ??
                    (_dataDeleteDateCommand = new WindowCommand(async obj =>
                    {
                        DataButtonsIsEnable = false;
                        DateTime date = new DateTime();
                        bool dataError = false;
                        if ((DataDeleteDateDay != string.Empty) && (DataDeleteDateMonth != string.Empty)
                                && (DataDeleteDateYear != string.Empty))
                        {
                            try
                            {
                                date = new DateTime(Int32.Parse(DataDeleteDateYear), Int32.Parse(DataDeleteDateMonth),
                                    Int32.Parse(DataDeleteDateDay));
                                StatusBar = "Удаление: " + date.Date.ToString();
                            }
                            catch (Exception ex)
                            {
                                dataError = true;
                                MessageBox.Show("Введите корректную дату!", ex.Message);
                            }
                            if (!dataError)
                            {
                                _DBManager.ScreenContextRemoveDate(date);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректную дату!");
                        }
                        DataButtonsIsEnable = true;
                        StatusBar = "Удаление завершено!";
                        GetDataLastRefreshDate();
                    }));
            }
        }

        private WindowCommand _dataAddDataCommand;
        public WindowCommand DataAddDataCommand
        {
            get
            {
                return _dataAddDataCommand ??
                    (_dataAddDataCommand = new WindowCommand(async obj =>
                    {
                        DataButtonsIsEnable = false;
                        ScreenContext db = new ScreenContext();
                        string textTextBox = DataAddDataTextBox;
                        string[] stringArr = textTextBox.Split('\n');
                        DateTime today = DateTime.Now.Date;
                        int lineError = 1;
                        bool error_input = false;
                        List<Screen> ScreenList = new List<Screen>();
                        var dates = db.Screens.FirstOrDefault(p => p.Date == today);
                        if (dates != null)
                        {
                            error_input = true;
                            MessageBox.Show("Сегодняшняя дата: " + today + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                        }
                        else
                        {
                            StatusBar = "Добавление: " + today.Date.ToString();
                        }
                        if (!error_input)
                        {
                            foreach (string newsplit in stringArr)
                            {
                                if (newsplit != "")
                                {
                                    try
                                    {
                                        var s = new Screen(newsplit, Localize.splitSpace);
                                        ScreenList.Add(s);
                                    }
                                    catch (Exception ex)
                                    {
                                        error_input = true;
                                        MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                                        "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                                    }
                                    lineError++;
                                }
                            }
                        }
                        if (!error_input)
                        {
                            try
                            {
                                _DBManager.ScreenContextAdd(ScreenList);
                            }
                            catch (Exception ex)
                            {
                                error_input = true;
                                MessageBox.Show("Ошибка загрузки даты за " + today + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                            }
                        }
                        if (!error_input)
                        {
                            MessageBox.Show("Обновление DATA за " + today + " завершено успешно!");
                        }
                        StatusBar = "Добавление завершено!";
                        DataButtonsIsEnable = true;
                        GetDataLastRefreshDate();
                    }));
            }
        }

        private WindowCommand _finvizFileDialogCommand;
        public WindowCommand FinvizFileDialogCommand
        {
            get
            {
                return _finvizFileDialogCommand ??
                    (_finvizFileDialogCommand = new WindowCommand(obj =>
                    {
                        FileDialogSelect fileDialogSelect = _fileManager.FileDialogSingle(Localize.txtFilter);
                        FinvizFilePath = fileDialogSelect != null ? fileDialogSelect.Path : String.Empty;
                    }));
            }
        }

        private WindowCommand _finvizRefreshCommand;
        public WindowCommand FinvizRefreshCommand
        {
            get
            {
                return _finvizRefreshCommand ??
                    (_finvizRefreshCommand = new WindowCommand(async obj =>
                    {
                        InfoButtonsIsEnable = false;
                        DescriptionContext db = new DescriptionContext();
                        string path = FinvizFilePath;
                        string fileText;
                        StreamReader file = null;
                        bool errorInput = false;                        
                        int lineError = 1;
                        List<Description> addFinvizToTable = new List<Description>();

                        try
                        {
                            file = new StreamReader(path);
                            fileText = await file.ReadToEndAsync();
                            file.Close();                            
                            string[] splitLines = fileText.Split(Localize.splitLines);
                            foreach (string line in splitLines)
                            {
                                if(!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                                {
                                    try
                                    {
                                        addFinvizToTable.Add(new Description(line, Localize.splitTabulation));
                                    }
                                    catch (Exception ex)
                                    {
                                        errorInput = true;
                                        MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                                        "\nРекомендуем удалить и заново загрузить день!", ex.Message);
                                    }
                                    lineError++;
                                }
                            }
                            if (!errorInput)
                            {
                                try
                                {
                                    _DBManager.DescriptionContextAdd(addFinvizToTable);
                                }
                                catch (Exception ex)
                                {
                                    errorInput = true;
                                    MessageBox.Show("Ошибка загрузки в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                                }
                            }
                            if (!errorInput)
                            {
                                MessageBox.Show("Обновление завершено успешно!");
                            }
                        }                        
                        catch (Exception ex)
                        {
                            MessageBox.Show("Выберите файл!", ex.Message);
                        }                        
                        InfoButtonsIsEnable = true;
                    }));
            }
        }

        private WindowCommand _aboutFileDialogCommand;
        public WindowCommand AboutFileDialogCommand
        {
            get
            {
                return _aboutFileDialogCommand ??
                    (_aboutFileDialogCommand = new WindowCommand(obj =>
                    {
                        FileDialogSelect fileDialogSelect = _fileManager.FileDialogSingle(Localize.txtFilter);
                        AboutFilePath = fileDialogSelect != null ? fileDialogSelect.Path : String.Empty;
                    }));
            }
        }

        private WindowCommand _aboutRefreshCommand;
        public WindowCommand AboutRefreshCommand
        {
            get
            {
                return _aboutRefreshCommand ??
                    (_aboutRefreshCommand = new WindowCommand(async obj =>
                    {
                        InfoButtonsIsEnable = false;
                        BusinessContext db = new BusinessContext();
                        string path = AboutFilePath;
                        string fileText;
                        StreamReader file = null;
                        bool errorInput = false;                        
                        int lineError = 1;
                        List<Business> addAboutToTable = new List<Business>();

                        try
                        {
                            file = new StreamReader(path);
                            fileText = await file.ReadToEndAsync();
                            file.Close();                            
                            string[] splitLines = fileText.Split(Localize.splitLines);
                            foreach (string line in splitLines)
                            {
                                if(!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                                {
                                    try
                                    {
                                        addAboutToTable.Add(new Business(line, Localize.splitTabulation));
                                    }
                                    catch (Exception ex)
                                    {
                                        errorInput = true;
                                        MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                                        "\nРекомендуем удалить и заново загрузить данные!", ex.Message);
                                    }
                                    lineError++;
                                }                                
                            }
                            if (!errorInput)
                            {
                                try
                                {
                                    _DBManager.BusinessContextAdd(addAboutToTable);
                                }
                                catch (Exception ex)
                                {
                                    errorInput = true;
                                    MessageBox.Show("Ошибка загрузки рода деятельности в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                                }
                            }
                            if (!errorInput)
                            {
                                MessageBox.Show("Обновление завершено успешно!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Выберите файл!", ex.Message);
                        }                        
                        InfoButtonsIsEnable = true;
                    }));
            }
        }

        private void SectorAdd(int sectorLevel)
        {
            InfoButtonsIsEnable = false;
            SectorContext db = new SectorContext();
            bool errorInput = false;

            List<Sector> sectorList = new List<Sector>();
            string text = SectorAddSectorTextBox;
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                {
                    errorInput = true;
                }
                sectorList = _Parser.SectorParce(text, sectorLevel);
            }
            catch (Exception ex)
            {
                errorInput = true;
                MessageBox.Show("Ошибка обновления!\n Рекомендуем загрузить информацию заново!", ex.Message);
            }
            if (!errorInput)
            {
                try
                {
                    _DBManager.SectorContextAdd(sectorList, sectorLevel);
                }
                catch (Exception ex)
                {
                    errorInput = true;
                    MessageBox.Show("Ошибка загрузки!\n Загрузите информацию заново!", ex.Message);
                }
            }
            if (!errorInput)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            InfoButtonsIsEnable = true;
        }
        private WindowCommand _sectorAddFirstSectorCommand;
        public WindowCommand SectorAddFirstSectorCommand
        {
            get
            {
                return _sectorAddFirstSectorCommand ??
                    (_sectorAddFirstSectorCommand = new WindowCommand(obj =>
                    {
                        int sectorLevel = 1;
                        SectorAdd(sectorLevel);
                    }));
            }
        }
        private WindowCommand _sectorAddSecondSectorCommand;
        public WindowCommand SectorAddSecondSectorCommand
        {
            get
            {
                return _sectorAddSecondSectorCommand ??
                    (_sectorAddSecondSectorCommand = new WindowCommand(obj =>
                    {
                        int sectorLevel = 2;
                        SectorAdd(sectorLevel);
                    }));
            }
        }
        private WindowCommand _sectorAddThirdSectorCommand;
        public WindowCommand SectorAddThirdSectorCommand
        {
            get
            {
                return _sectorAddThirdSectorCommand ??
                    (_sectorAddThirdSectorCommand = new WindowCommand(async obj =>
                    {
                        int sectorLevel = 3;
                        SectorAdd(sectorLevel);
                    }));
            }
        }

        private WindowCommand _reportFileDialogCommand;
        public WindowCommand ReportFileDialogCommand
        {
            get
            {
                return _reportFileDialogCommand ??
                    (_reportFileDialogCommand = new WindowCommand(obj =>
                    {
                        FileDialogSelect fileDialogSelect = _fileManager.FileDialogSingle(Localize.txtFilter);                        
                        ReportFilePath = fileDialogSelect != null ? fileDialogSelect.Path : string.Empty;
                    }));
            }
        }

        private WindowCommand _reportRefreshCommand;
        public WindowCommand ReportRefreshCommand
        {
            get
            {
                return _reportRefreshCommand ??
                    (_reportRefreshCommand = new WindowCommand(async obj =>
                    {
                        ReportButtonsIsEnable = false;
                        ReportContext db = new ReportContext();
                        DateTime date = new DateTime();
                        string pathLine = ReportFilePath;
                        bool errorInput = false;
                        StreamReader openFile;
                        string earningTime = Localize.ReportTimeBO;
                        List<Report> addReportToTable = new List<Report>();
                        try
                        {
                            date = _Parser.ParcePathToDate(ReportFilePath);
                            var dates = db.Reports.FirstOrDefault(p => p.Date == date);
                            if (dates != null)
                            {
                                errorInput = true;
                                MessageBox.Show("Дата: " + date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                            }
                        }
                        catch (Exception ex)
                        {
                            errorInput = true;
                            MessageBox.Show("Выберите файл!", ex.Message);
                        }
                        if (!errorInput)
                        {
                            try
                            {
                                openFile = new StreamReader(pathLine);
                                string fileText = await openFile.ReadToEndAsync();
                                openFile.Close();
                                string[] splitLines = fileText.Split(Localize.splitLines);
                                foreach (string line in splitLines)
                                {
                                    string ticker = line.Replace("\r", "");
                                    if (!string.IsNullOrEmpty(ticker) && !string.IsNullOrWhiteSpace(ticker))
                                    {
                                        if (ticker.ToUpper() == Localize.ReportTimeSplit)
                                        {
                                            earningTime = Localize.ReportTimeAC;
                                        }
                                        addReportToTable.Add(new Report(ticker, date, earningTime));
                                    }                                    
                                }
                            }
                            catch (Exception ex)
                            {
                                errorInput = true;
                                MessageBox.Show("Ошибка обновления репортов за " + date + " \nРекомендуем удалить и заново загрузить день!", ex.Message);
                            }
                        }
                        if (!errorInput)
                        {
                            try
                            {
                                _DBManager.ReportContextAdd(addReportToTable);
                            }
                            catch (Exception ex)
                            {
                                errorInput = true;
                                MessageBox.Show("Ошибка загрузки репортов за " + date + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                            }
                        }
                        if (!errorInput)
                        {
                            MessageBox.Show("Обновление завершено успешно!");
                        }
                        ReportButtonsIsEnable = true;
                    }));
            }
        }

        private void ReportAdd(string day)
        {
            ReportButtonsIsEnable = false;
            ReportContext db = new ReportContext();
            string text = ReportAddReportTextBox;
            string[] splitLines = text.Split(Localize.splitLines);
            bool errorInput = false;
            DateTime date = _DayShiftValidator.GetShift(day);
            List<Report> ReportList = new List<Report>();
            string earningTime = Localize.ReportTimeBO;
            int lineError = 1;

            var dates = db.Reports.FirstOrDefault(p => p.Date == date);
            if (dates == null)
            {
                try
                {
                    foreach (string line in splitLines)
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                        {
                            string ticker = line.Replace("\r", "");
                            if (ticker.ToUpper() == Localize.ReportTimeSplit)
                            {
                                earningTime = Localize.ReportTimeAC;
                            }
                            ReportList.Add(new Report(ticker, date, earningTime));
                        }
                        lineError++;
                    }
                }
                catch (Exception ex)
                {
                    errorInput = true;
                    MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                        "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                }
            }
            else
            {
                errorInput = true;
                MessageBox.Show("Дата: " + date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
            }
            if (!errorInput)
            {
                try
                {
                    _DBManager.ReportContextAdd(ReportList);
                }
                catch (Exception ex)
                {
                    errorInput = true;
                    MessageBox.Show("Ошибка загрузки репортов за " + date + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                }
            }
            if (!errorInput)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            ReportButtonsIsEnable = true;
        }
        private WindowCommand _reportAddYesterdayReportCommand;
        public WindowCommand ReportAddYesterdayReportCommand
        {
            get
            {
                return _reportAddYesterdayReportCommand ??
                    (_reportAddYesterdayReportCommand = new WindowCommand(obj =>
                    {
                        string day = Localize.DayYesterday;
                        ReportAdd(day);
                    }));
            }
        }
        private WindowCommand _reportAddTodayReportCommand;
        public WindowCommand ReportAddTodayReportCommand
        {
            get
            {
                return _reportAddTodayReportCommand ??
                    (_reportAddTodayReportCommand = new WindowCommand(obj =>
                    {
                        string day = Localize.DayToday;
                        ReportAdd(day);
                    }));
            }
        }
        private WindowCommand _reportAddTomorrowReportCommand;
        public WindowCommand ReportAddTomorrowReportCommand
        {
            get
            {
                return _reportAddTomorrowReportCommand ??
                    (_reportAddTomorrowReportCommand = new WindowCommand(async obj =>
                    {
                        string day = Localize.DayTomorrow;
                        ReportAdd(day);
                    }));
            }
        }

        private WindowCommand _reportDeleteDateCommand;
        public WindowCommand ReportDeleteDateCommand
        {
            get
            {
                return _reportDeleteDateCommand ??
                    (_reportDeleteDateCommand = new WindowCommand(obj =>
                    {
                        ReportButtonsIsEnable = false;
                        DateTime date = new DateTime();
                        bool dataError = false;
                        if ((ReportDeleteDateDay != string.Empty) && (ReportDeleteDateMonth != string.Empty)
                                && (ReportDeleteDateYear != string.Empty))
                        {
                            try
                            {
                                date = new DateTime(Int32.Parse(ReportDeleteDateYear), Int32.Parse(ReportDeleteDateMonth),
                                        Int32.Parse(ReportDeleteDateDay));
                                _DBManager.ReportContextRemove(date);
                            }
                            catch (Exception ex)
                            {
                                dataError = true;
                                MessageBox.Show("Введите корректную дату!", ex.Message);
                            }

                        }                        
                        ReportButtonsIsEnable = true;
                    }));
            }
        }

        private WindowCommand _dividendFileDialogCommand;
        public WindowCommand DividendFileDialogCommand
        {
            get
            {
                return _dividendFileDialogCommand ??
                    (_dividendFileDialogCommand = new WindowCommand(obj =>
                    {
                        FileDialogSelect fileDialogSelect = _fileManager.FileDialogSingle(Localize.txtFilter);
                        DividendFilePath = fileDialogSelect != null ? fileDialogSelect.Path : string.Empty;
                    }));
            }
        }

        private WindowCommand _dividendRefreshCommand;
        public WindowCommand DividendRefreshCommand
        {
            get
            {
                return _dividendRefreshCommand ??
                    (_dividendRefreshCommand = new WindowCommand(async obj =>
                    {
                        DividendButtonIsEnable = false;
                        DividendContext db = new DividendContext();
                        string pathLine = DividendFilePath;
                        StreamReader file = null;
                        DateTime date = new DateTime();
                        bool errorInput = false;
                        int lineError = 1;
                        List<Dividend> addDividendsToTable = new List<Dividend>();
                        try
                        {
                            date = _Parser.ParcePathToDate(pathLine);
                            file = new StreamReader(pathLine);
                            var dates = db.Dividends.FirstOrDefault(p => p.Date == date);
                            if (dates != null)
                            {
                                errorInput = true;
                                MessageBox.Show("Дата: " + date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                            }

                        }
                        catch (Exception ex)
                        {
                            errorInput = true;
                            MessageBox.Show("Выберите файл!", ex.Message);
                        }
                        if (!errorInput)
                        {
                            string fileText = await file.ReadToEndAsync();
                            file.Close();
                            string[] splitLines = fileText.Split(Localize.splitLines);
                            try
                            {
                                foreach (string line in splitLines)
                                {
                                    if(!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                                    {
                                        addDividendsToTable.Add(new Dividend(line, Localize.splitSpace, date));
                                        lineError++;
                                    }
                                }                                
                            }
                            catch (Exception ex)
                            {
                                errorInput = true;
                                MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                                                     "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                            }
                        }
                        if (!errorInput)
                        {
                            try
                            {
                                _DBManager.DividendContextAdd(addDividendsToTable);
                            }
                            catch (Exception ex)
                            {
                                errorInput = true;
                                MessageBox.Show("Ошибка загрузки дивидендов за " + date + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                            }
                        }
                        if (!errorInput)
                        {
                            MessageBox.Show("Обновление завершено успешно!");
                        }
                        DividendButtonIsEnable = true;
                    }));
            }
        }

        private void DividendAdd(string day)
        {
            DividendButtonIsEnable = false;
            DividendContext db = new DividendContext();
            string text = DividendAddDivTextBox;
            string[] splitLines = text.Split('\n');
            bool errorInput = false;
            int lineError = 1;
            DateTime date = new DateTime();
            date = _DayShiftValidator.GetShift(day);            
            List<Dividend> DividendList = new List<Dividend>();
            var dates = db.Dividends.FirstOrDefault(p => p.Date == date);
            if (dates == null)
            {
                try
                {
                    foreach (string line in splitLines)
                    {
                        if(!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                        {
                            DividendList.Add(new Dividend(line, Localize.splitSpace, date));
                        }
                        lineError++;
                    }                   
                }
                catch (Exception ex)
                {
                    errorInput = true;
                    MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + lineError +
                        "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                }
            }
            else
            {
                errorInput = true;
                MessageBox.Show("Дата: " + date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
            }
            if (!errorInput)
            {               
                try
                {
                    _DBManager.DividendContextAdd(DividendList);
                }
                catch (Exception ex)
                {                    
                    errorInput = true;
                    MessageBox.Show("Ошибка загрузки дивидендов за " + date + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                }
            }
            if (!errorInput)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            DividendButtonIsEnable = true;
        }
        private WindowCommand _dividendAddYesterdayDivCommand;
        public WindowCommand DividendAddYesterdayDivCommand
        {
            get
            {
                return _dividendAddYesterdayDivCommand ??
                    (_dividendAddYesterdayDivCommand = new WindowCommand(obj =>
                    {
                        string day = Localize.DayYesterday;
                        DividendAdd(day);
                    }));
            }
        }
        private WindowCommand _dividendAddTodayDivCommand;
        public WindowCommand DividendAddTodayDivCommand
        {
            get
            {
                return _dividendAddTodayDivCommand ??
                    (_dividendAddTodayDivCommand = new WindowCommand(obj =>
                    {
                        string day = Localize.DayToday;
                        DividendAdd(day);
                    }));
            }
        }
        private WindowCommand _dividendAddTomorrowDivCommand;
        public WindowCommand DividendAddTomorrowDivCommand
        {
            get
            {
                return _dividendAddTomorrowDivCommand ??
                    (_dividendAddTomorrowDivCommand = new WindowCommand(obj =>
                    {
                        string day = Localize.DayTomorrow;
                        DividendAdd(day);
                    }));
            }
        }

        private WindowCommand _dividendDeleteDateCommand;
        public WindowCommand DividendDeleteDateCommand
        {
            get
            {
                return _dividendDeleteDateCommand ??
                    (_dividendDeleteDateCommand = new WindowCommand(obj =>
                      {
                          DividendButtonIsEnable = false;
                          DateTime date = new DateTime();
                          bool errorInput = false;
                          if ((DividendDeleteDateDay != string.Empty) && (DividendDeleteDateMonth != string.Empty) 
                                    && (DividendDeleteDateYear != string.Empty))
                          {
                              try
                              {
                                  date = new DateTime(Int32.Parse(DividendDeleteDateYear), Int32.Parse(DividendDeleteDateMonth),
                                      Int32.Parse(DividendDeleteDateDay));
                              }
                              catch (Exception ex)
                              {
                                  errorInput = true;
                                  MessageBox.Show("Введите корректную дату!", ex.Message);
                              }
                              if (!errorInput)
                              {
                                  _DBManager.DividendContextRemove(date);
                              }
                          }
                          else
                          {
                              MessageBox.Show("Введите корректную дату!");
                          }
                          DividendButtonIsEnable = true;
                      }));
            }
        }        

        private async void GetDataLastRefreshDate()
        {
            await Task.Run(() =>
            {
                ScreenContext db = new ScreenContext();
                var isEmpty = db.Screens.OrderByDescending(p => p.Date).FirstOrDefault();

                if (isEmpty == null)
                {
                    LastUpdate = Localize.EmptyBase;
                }
                else
                {
                    LastUpdate = isEmpty.Date.ToShortDateString();
                }
            });
        }
    }
}
