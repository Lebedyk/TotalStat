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
        private void FileDialog_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();            
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(e.OriginalSource == AddFile_Data)
            {
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
            if(e.OriginalSource == AddFile_Finviz)
            {
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == true)
                {
                    FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                    Finviz_FilePath.Text = filedialogselect.Path;
                }
            }
            if(e.OriginalSource == AddFile_About)
            {
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == true)
                {
                    FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                    About_FilePath.Text = filedialogselect.Path;
                }
            }
            if (e.OriginalSource == AddFile_Report)
            {
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == true)
                {
                    FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                    Report_FilePath.Text = filedialogselect.Path;
                }
            }
            if (e.OriginalSource == AddFile_Dividend)
            {
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == true)
                {
                    FileDialogSelect filedialogselect = new FileDialogSelect(dlg.FileName);
                    Dividend_FilePath.Text = filedialogselect.Path;
                }
            }
        }
        private void Remove_Execute(object sender, EventArgs e)
        {
            ChoosenFiles.Remove(SelectedItems_ListBox.SelectedItem as FileDialogSelect);
        }
        private async void Refresh_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.OriginalSource == Data_Refresh)
            {
                              
                
            }
            if (e.OriginalSource == Finviz_Refresh)
            {

            }
            if(e.OriginalSource == About_Refresh)
            {

            }
            if (e.OriginalSource == Report_Refresh)
            {

            }            
            if (e.OriginalSource == Dividend_Refresh)
            {
                DividendContext dividendcontext = new DividendContext();                
                string path = Dividend_FilePath.Text;
                string line;
                int index;
                string date;
                string[] date_arr;
                StreamReader file;
                bool selectfile = false;
                if(path == "")
                {
                    path = "error";
                    date_arr = null;
                    date = null;
                    file = null;
                    MessageBox.Show("Выберите файл!");
                }
                else
                {
                    file = new StreamReader(path);
                    index = path.LastIndexOf("\\");
                    date = path.Substring(index + 1);
                    date_arr = date.Split('.');
                    selectfile = true;
                }
                
                DateTime file_date = new DateTime();
                bool error_input = false;
                if(selectfile)
                {
                    try
                    {
                        file_date = new DateTime(Int32.Parse(date_arr[0]), Int32.Parse(date_arr[1]), Int32.Parse(date_arr[2]));
                    }
                    catch (Exception ex)
                    {
                        error_input = true;
                        MessageBox.Show("Ошибка! Неверный формат: " + date + "\nПравильный формат даты: год.месяц.день\n(0000.00.00)", ex.Message);
                    }
                }
                else
                {
                    error_input = true;
                }                
                
                while ((!error_input) && ((line = await file.ReadLineAsync()) != null))
                {
                    string[] split_Arr = line.Split(' ');
                    var transaction = dividendcontext.Database.BeginTransaction();
                    try
                    {
                        dividendcontext.Dividends.Add(new Dividend { Ticker = split_Arr[0], Sum = Double.Parse(split_Arr[1]), Date = file_date });
                        await dividendcontext.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        error_input = true;
                        MessageBox.Show("Ошибка: неверный формат данных!\n Строка ошибки: " + split_Arr[0] +" "+ split_Arr[1] +
                            "\nРекомендуем удалить и заново загрузить день!", ex.Message);
                    }
                }                
                if(!error_input)
                {
                    MessageBox.Show("Обновление завершено успешно!");
                }
                else
                {
                    MessageBox.Show("Ошибка обновления!");
                }                
            }
        }        
        private void DeleteDate_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.OriginalSource == Dividend_DeleteDate)
            {
                DateTime date = new DateTime();
                bool dataerror = false;
                if((Dividend_DeleteDate_Day.Text != "") && (Dividend_DeleteDate_Month.Text!="") && (Dividend_DeleteDate_Year.Text!=""))
                {
                    try
                    {
                        date = new DateTime(Int32.Parse(Dividend_DeleteDate_Year.Text), Int32.Parse(Dividend_DeleteDate_Month.Text),
                            Int32.Parse(Dividend_DeleteDate_Day.Text));
                    }
                    catch
                    {
                        dataerror = true;
                        MessageBox.Show("Введите корректную дату!");
                    }
                    if(!dataerror)
                    {
                        DividendContext db = new DividendContext();
                        var dates = db.Dividends.Where(p => p.Date == date);                        
                        if (dates.Count() == 0)
                        {
                            MessageBox.Show("Дата не найдена!");
                        }
                        foreach (Dividend ololo in dates)
                        {
                            MessageBox.Show(ololo.Ticker);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректную дату!");
                }
            }
        }
    }
}
