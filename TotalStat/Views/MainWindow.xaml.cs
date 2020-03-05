using System.Configuration;
using System.Data.SqlClient;
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
        AppSizeGeometry config;
        ConnectionSet connectionSet;

        public MainWindow()
        {
            connectionSet = new ConnectionSet();
            DataContext = new MainWindowViewModel();
            InitializeComponent();
            config = new AppSizeGeometry();
            
        }       
    }    
}
