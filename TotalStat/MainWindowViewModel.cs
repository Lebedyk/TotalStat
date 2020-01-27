using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TotalStat
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            { 
                isVisible = value;
                OnPropertyChanged("IsVisible");                
            }
        }
        private WindowCommand _openRedactorWindowCommand;
        public WindowCommand OpenRedactorWindowCommand
        {
            get
            {
                return _openRedactorWindowCommand ??
                    (_openRedactorWindowCommand = new WindowCommand(obj =>
                    {                        
                        IsVisible = false;
                        RedactorWindow redactorwindow = new RedactorWindow();
                        redactorwindow.Owner = App.Current.MainWindow;
                        redactorwindow.Show();
                    }));
            }
        }
        private WindowCommand _openAppWindowCommand;
        public WindowCommand OpenAppWindowCommand
        {
            get
            {
                return _openAppWindowCommand ??
                    (_openAppWindowCommand = new WindowCommand(obj =>
                    {
                        IsVisible = false;
                        AppWindow appWindow = new AppWindow();
                        appWindow.Owner = App.Current.MainWindow;
                        appWindow.Show();
                    }));
            }
        }

        private WindowCommand _exitCommand;
        public WindowCommand ExitCommand
        {
            get
            {
                return _exitCommand ??
                    (_exitCommand = new WindowCommand(obj =>
                   {
                       App.Current.MainWindow.Close();
                   }));
            }
        }
        private WindowCommand _openFAQ;
        public WindowCommand OpenFAQ
        {
            get
            {
                return _openFAQ ??
                    (_openFAQ = new WindowCommand(obj =>
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\FAQ.txt"))
                        {
                            Process.Start(Directory.GetCurrentDirectory() + "\\FAQ.txt");
                        }
                    }));
            }
        }
    }
}
