using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppConfiguration config;
        public MainWindow()
        {
            InitializeComponent();
            config = new AppConfiguration();            
        } 
        private void OpenWindow_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.OriginalSource == LoadApp)
            {
                AppWindow appwindow = new AppWindow();
                appwindow.Owner = this;
                appwindow.Show();
                this.Visibility = Visibility.Collapsed;
            }
            if(e.OriginalSource == LoadRedactor)
            {
                RedactorWindow redactorwindow = new RedactorWindow();
                redactorwindow.Owner = this;
                redactorwindow.Show();
                this.Visibility = Visibility.Collapsed;
            }            
        }
        private void Exit_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void FAQ_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(File.Exists(Directory.GetCurrentDirectory() + "\\FAQ.txt"))
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\FAQ.txt");
            }
        }
    }    
}
