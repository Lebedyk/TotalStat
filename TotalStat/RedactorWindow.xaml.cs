using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Data.Entity;
using System.IO;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for RedactorWindow.xaml
    /// </summary>
    public partial class RedactorWindow : Window
    {
        private ObservableCollection<FileDialogSelect> choosenFiles;
        public RedactorWindow()
        {
            InitializeComponent();
            this.Closed += RedactorWindow_Closed;
            ChoosenFiles = new ObservableCollection<FileDialogSelect>();
            SelectedItems_ListBox.ItemsSource = ChoosenFiles;
        }

        ObservableCollection<FileDialogSelect> ChoosenFiles
        { get {return choosenFiles; }
            set { choosenFiles = value;}
        }


        private void RedactorWindow_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
        } 
        private void Data_FileDialog_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == true)
            {
                if (ChoosenFiles == null)
                {
                    ChoosenFiles = new ObservableCollection<FileDialogSelect>();
                    foreach (string filename in dlg.FileNames)
                    {
                        ChoosenFiles.Add(new FileDialogSelect(filename));
                    }
                }
                else
                {
                    foreach (string filename in dlg.FileNames)
                    {
                        bool findsimilar = false;
                        for (int i = 0; i < ChoosenFiles.Count; i++)
                        {
                            if (ChoosenFiles[i].Path == filename)
                            {
                                findsimilar = true;
                                break;
                            }
                        }
                        if (!findsimilar)
                        {
                            ChoosenFiles.Add(new FileDialogSelect(filename));
                        }
                    }
                }
            }           
        }
        private void Finviz_FileDialog_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                FinvizFilePath.Text = filedialogselect.Path;
            }            
        }
        private void About_FileDialog_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                AboutFilePath.Text = filedialogselect.Path;
            }            
        }
        private void Report_FileDialog_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                ReportFilePath.Text = filedialogselect.Path;
            }            
        }
        private void Dividend_FileDialog_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                DividendFilePath.Text = filedialogselect.Path;
            }            
        }
        private void Data_Remove_Execute(object sender, EventArgs e)
        {
            ChoosenFiles.Remove(SelectedItems_ListBox.SelectedItem as FileDialogSelect);
        }
        private async void Data_Refresh_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(ChoosenFiles.Count()>0)
            {
                DataRefreshButton.IsEnabled = false;
                foreach (FileDialogSelect fileDialog in ChoosenFiles.ToArray())
                {
                    ScreenContext db = new ScreenContext();
                    string line = null;
                    string date = null;
                    string[] date_arr = null;
                    StreamReader file = null;
                    DateTime file_date = new DateTime();
                    bool error_input = false;
                    bool selectfile = false;
                    int line_error = 1;
                    List<Screen> addScreenToTable = new List<Screen>();
                    try
                    {
                        file = new StreamReader(fileDialog.Path);
                        date = fileDialog.Name;
                        date_arr = date.Split('.');
                        selectfile = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка! \nНеправильный путь или имя файла: "+fileDialog.Path, ex.Message);
                    }
                    if (selectfile)
                    {
                        try
                        {
                            file_date = new DateTime(Int32.Parse(date_arr[0]), Int32.Parse(date_arr[1]), Int32.Parse(date_arr[2]));
                            var dates = db.Screens.FirstOrDefault(p => p.Date == file_date);
                            if (dates != null)
                            {
                                error_input = true;
                                MessageBox.Show("Дата: " + file_date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                            }
                        }
                        catch (Exception ex)
                        {
                            error_input = true;
                            MessageBox.Show("Ошибка! Неверный формат: " + date + "\nПравильный формат даты: год.месяц.день\n(0000.00.00)", ex.Message);
                        }
                        while ((!error_input) && ((line = await file.ReadLineAsync()) != null))
                        {
                            string[] split_Arr = line.Split('\t');
                            try
                            {
                                addScreenToTable.Add(new Screen { Ticker = split_Arr[0], Open = Double.Parse(split_Arr[1]), 
                                                                  Close = Double.Parse(split_Arr[2]), Nite = Double.Parse(split_Arr[3]),
                                                                  NitePercent = Double.Parse(split_Arr[4]), ImbNY = Int32.Parse(split_Arr[5]),
                                                                  ImbEx = Int32.Parse(split_Arr[6]), PremVolume= Int32.Parse(split_Arr[7]),
                                                                  Date = file_date 
                                                                });
                            }
                            catch (Exception ex)
                            {
                                error_input = true;
                                MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + line_error +
                                "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                            }
                            line_error++;
                        }
                        file.Close();
                        if (!error_input)
                        {
                            var transaction = db.Database.BeginTransaction();
                            try
                            {
                                db.Screens.AddRange(addScreenToTable);
                                await db.SaveChangesAsync();
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                error_input = true;
                                MessageBox.Show("Ошибка загрузки даты за " + date + " в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                            }
                        }
                    }
                    else
                    {
                        error_input = true;
                    }
                    if (selectfile && !error_input)
                    {
                        MessageBox.Show("Обновление DATA за "+date+" завершено успешно!");
                    }
                }
                DataRefreshButton.IsEnabled = true;
            }            
        }
        private async void Finviz_Refresh_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            FinvizRefreshButton.IsEnabled = false;
            DescriptionContext db = new DescriptionContext();
            string path = FinvizFilePath.Text;
            string line;            
            StreamReader file = null;
            bool error_input = false;
            bool selectfile = false;
            int line_error = 1;
            List<Description> addFinvizToTable = new List<Description>();

            try
            {                
                file = new StreamReader(path);                
                selectfile = true;
                while ((!error_input) && ((line = await file.ReadLineAsync()) != null))
                {
                    string[] split_Arr = line.Split('\t');                    
                    try
                    {
                        addFinvizToTable.Add(new Description
                                    {
                                        Ticker = split_Arr[0],
                                        CompanyName = split_Arr[1],
                                        Sector = split_Arr[2],
                                        Industry = split_Arr[3],
                                        Country = split_Arr[4],
                                        MarketCap = Convert.ToDouble(split_Arr[5]),
                                        ShortFloat = Convert.ToDouble(split_Arr[6]),
                                        AvarageVolume = Convert.ToDouble(split_Arr[7])
                                    });                        
                    }
                    catch (Exception ex)
                    {                        
                        error_input = true;
                        MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + line_error +
                        "\nРекомендуем удалить и заново загрузить день!", ex.Message);                        
                    }
                    line_error++;
                }
                file.Close();
                if(!error_input)
                {
                    var transaction = db.Database.BeginTransaction();
                    try
                    {
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE[Descriptions]");
                        db.Descriptions.AddRange(addFinvizToTable);
                        await db.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        error_input = true;
                        MessageBox.Show("Ошибка загрузки в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Выберите файл!", ex.Message);
            }
            if (selectfile && !error_input)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            FinvizRefreshButton.IsEnabled = true;
        }
        private async void About_Refresh_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AboutRefreshButton.IsEnabled = false;
            BusinessContext db = new BusinessContext();
            string path = AboutFilePath.Text;
            string line;
            StreamReader file = null;
            bool error_input = false;
            bool selectfile = false;
            int line_error = 1;
            List<Business> addAboutToTable = new List<Business>();

            try
            {
                file = new StreamReader(path);
                selectfile = true;
                while ((!error_input) && ((line = await file.ReadLineAsync()) != null))
                {
                    string[] split_Arr = line.Split('\t');
                    try
                    {
                        addAboutToTable.Add(new Business
                        {
                            Ticker = split_Arr[0],
                            Biz = split_Arr[1],                            
                        });
                    }
                    catch (Exception ex)
                    {
                        error_input = true;
                        MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + line_error +
                        "\nРекомендуем удалить и заново загрузить данные!", ex.Message);
                    }
                    line_error++;
                }
                file.Close();
                if (!error_input)
                {
                    var transaction = db.Database.BeginTransaction();
                    try
                    {
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE[Businesses]");
                        db.Businesses.AddRange(addAboutToTable);
                        await db.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        error_input = true;
                        MessageBox.Show("Ошибка загрузки рода деятельности в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите файл!", ex.Message);
            }
            if (selectfile && !error_input)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            AboutRefreshButton.IsEnabled = true;
        }    
        private async void Report_Refresh_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ReportRefreshButton.IsEnabled = false;
            ReportContext db = new ReportContext();
            string path = ReportFilePath.Text;
            string line;            
            string date = null;
            string[] date_arr = null;
            StreamReader file = null;
            bool selectfile = false;
            string earningtime = "Before Open";
            List<Report> addReportToTable = new List<Report>();

            try
            {
                int index;
                file = new StreamReader(path);
                index = path.LastIndexOf("\\");
                date = path.Substring(index + 1);
                date_arr = date.Split('.');
                selectfile = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите файл!", ex.Message);
            }

            DateTime file_date = new DateTime();
            bool error_input = false;
            if (selectfile)
            {
                try
                {
                    file_date = new DateTime(Int32.Parse(date_arr[0]), Int32.Parse(date_arr[1]), Int32.Parse(date_arr[2]));
                    var dates = db.Reports.FirstOrDefault(p => p.Date == file_date);
                    if (dates != null)
                    {
                        error_input = true;
                        MessageBox.Show("Дата: " + file_date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                    }
                }
                catch (Exception ex)
                {
                    error_input = true;
                    MessageBox.Show("Ошибка! Неверный формат: " + date + "\nПравильный формат даты: год.месяц.день\n(0000.00.00)", ex.Message);
                }
                while ((!error_input) && ((line = await file.ReadLineAsync()) != null))
                {
                    if (line.ToUpper() == "AFTER")
                    {
                        earningtime = "After Close";
                    }                   
                    try
                    {
                        addReportToTable.Add(new Report { Ticker = line, EarningTime = earningtime, Date = file_date });                        
                    }
                    catch (Exception ex)
                    {                        
                        error_input = true;
                        MessageBox.Show("Ошибка обновления репортов за "+date+" \nРекомендуем удалить и заново загрузить день!", ex.Message);
                    }
                }
                file.Close();
                if(!error_input)
                {
                    var transaction = db.Database.BeginTransaction();
                    try
                    {                        
                        db.Reports.AddRange(addReportToTable);
                        await db.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        error_input = true;
                        MessageBox.Show("Ошибка загрузки репортов за "+date+" в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                    }
                }                
            }
            else
            {
                error_input = true;
            }            
            if (selectfile && !error_input)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            ReportRefreshButton.IsEnabled = true;
        }
        private async void Dividend_Refresh_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            DividendRefreshButton.IsEnabled = false;
            DividendContext db = new DividendContext();
            string path = DividendFilePath.Text;
            string line = null;
            string date = null;
            string[] date_arr = null;
            StreamReader file = null;
            DateTime file_date = new DateTime();
            bool error_input = false;
            bool selectfile = false;
            int line_error = 1;
            List<Dividend> addDividendsToTable = new List<Dividend>();
            
            try
            {
                int index;
                file = new StreamReader(path);
                index = path.LastIndexOf("\\");
                date = path.Substring(index + 1);
                date_arr = date.Split('.');
                selectfile = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите файл!", ex.Message);
            }
            
            if (selectfile)
            {
                try
                {
                    file_date = new DateTime(Int32.Parse(date_arr[0]), Int32.Parse(date_arr[1]), Int32.Parse(date_arr[2]));
                    var dates = db.Dividends.FirstOrDefault(p => p.Date == file_date);
                    if (dates != null)
                    {
                        error_input = true;
                        MessageBox.Show("Дата: " + file_date + " уже загружена! \n Рекомендуем удалить и загрузить день заново!");
                    }
                }
                catch (Exception ex)
                {
                    error_input = true;
                    MessageBox.Show("Ошибка! Неверный формат: " + date + "\nПравильный формат даты: год.месяц.день\n(0000.00.00)", ex.Message);
                }
                while ((!error_input) && ((line = await file.ReadLineAsync()) != null))
                {
                    string[] split_Arr = line.Split(' ');                    
                    try
                    {
                        addDividendsToTable.Add(new Dividend { Ticker = split_Arr[0], Sum = Double.Parse(split_Arr[1]), Date = file_date });
                        
                    }
                    catch (Exception ex)
                    {
                        error_input = true;
                        MessageBox.Show("Ошибка обновления!\n Строка ошибки: " + line_error +
                        "\nРекомендуем удалить и загрузить день заново!", ex.Message);
                    }
                    line_error++;
                }
                file.Close();
                if(!error_input)
                {
                    var transaction = db.Database.BeginTransaction();
                    try
                    {
                        db.Dividends.AddRange(addDividendsToTable);
                        await db.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        error_input = true;
                        MessageBox.Show("Ошибка загрузки дивидендов за "+date+" в базу данных! \nРекомендуем удалить и заново загрузить день!", ex.Message);
                    }
                }
            }
            else
            {
                error_input = true;
            }            
            if (selectfile && !error_input)
            {
                MessageBox.Show("Обновление завершено успешно!");
            }
            DividendRefreshButton.IsEnabled = true;
        }
        private async void Data_DeleteDate_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            DataDeleteDateButton.IsEnabled = false;
            DateTime date = new DateTime();
            bool dataerror = false;
            if ((DataDeleteDateDay.Text != "") && (DataDeleteDateMonth.Text != "") && (DataDeleteDateYear.Text != ""))
            {
                try
                {
                    date = new DateTime(Int32.Parse(DataDeleteDateYear.Text), Int32.Parse(DataDeleteDateMonth.Text),
                        Int32.Parse(DataDeleteDateDay.Text));
                }
                catch (Exception ex)
                {
                    dataerror = true;
                    MessageBox.Show("Введите корректную дату!", ex.Message);
                }
                if (!dataerror)
                {
                    ScreenContext db = new ScreenContext();
                    var dates = db.Screens.Where(p => p.Date == date);
                    if (dates.Count() > 0)
                    {
                        db.Screens.RemoveRange(dates);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Удаление DATA за " + date + " успешно завершено!");
                    }
                    else
                    {
                        MessageBox.Show("Дата не найдена!");
                    }                                 
                }
            }
            else
            {
                MessageBox.Show("Введите корректную дату!");
            }
            DataDeleteDateButton.IsEnabled = true;
        }
        private void Report_DeleteDate_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ReportDeleteDateButton.IsEnabled = false;
            DateTime date = new DateTime();
            bool dataerror = false;
            if ((ReportDeleteDateDay.Text != "") && (ReportDeleteDateMonth.Text != "") && (ReportDeleteDateYear.Text != ""))
            {
                try
                {
                    date = new DateTime(Int32.Parse(ReportDeleteDateYear.Text), Int32.Parse(ReportDeleteDateMonth.Text),
                        Int32.Parse(ReportDeleteDateDay.Text));
                }
                catch (Exception ex)
                {
                    dataerror = true;
                    MessageBox.Show("Введите корректную дату!", ex.Message);
                }
                if (!dataerror)
                {
                    ReportContext db = new ReportContext();
                    var dates = db.Reports.Where(p => p.Date == date);
                    if (dates.Count() == 0)
                    {
                        MessageBox.Show("Дата не найдена!");
                    }
                    else
                    {
                        db.Reports.RemoveRange(dates);
                        db.SaveChangesAsync();
                        MessageBox.Show("Удаление репортов за "+date+"  успешно завершено!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите корректную дату!");
            }
            ReportDeleteDateButton.IsEnabled = true;
        }
        private void Dividend_DeleteDate_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            DividendDeleteDateButton.IsEnabled = false;
            DateTime date = new DateTime();
            bool dataerror = false;
            if ((DividendDeleteDateDay.Text != "") && (DividendDeleteDateMonth.Text != "") && (DividendDeleteDateYear.Text != ""))
            {
                try
                {
                    date = new DateTime(Int32.Parse(DividendDeleteDateYear.Text), Int32.Parse(DividendDeleteDateMonth.Text),
                        Int32.Parse(DividendDeleteDateDay.Text));
                }
                catch (Exception ex)
                {
                    dataerror = true;
                    MessageBox.Show("Введите корректную дату!", ex.Message);
                }
                if (!dataerror)
                {
                    DividendContext db = new DividendContext();
                    var dates = db.Dividends.Where(p => p.Date == date);
                    if (dates.Count() == 0)
                    {
                        MessageBox.Show("Дата не найдена!");
                    }
                    else
                    {
                        db.Dividends.RemoveRange(dates);
                        db.SaveChangesAsync();
                        MessageBox.Show("Удаление дивидендов за "+date+" успешно завершено!");
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Введите корректную дату!");
            }
            DividendDeleteDateButton.IsEnabled = true;
        }
    }
}
