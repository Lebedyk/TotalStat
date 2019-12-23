using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenApp_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AppWindow appwindow = new AppWindow();
            appwindow.Show();
            this.Hide();
        }
        private void OpenRedactor_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            RedactorWindow redactorwindow = new RedactorWindow();
            redactorwindow.Owner = this;
            redactorwindow.Show();
            this.IsEnabled = false;
        }
        private void Exit_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }


    }
    
}
