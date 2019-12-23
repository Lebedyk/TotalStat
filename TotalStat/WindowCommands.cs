using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TotalStat
{
    public class WindowCommands
    {
        static WindowCommands()
        {
            Click_OpenApp = new RoutedCommand("Click_OpenApp", typeof(MainWindow));
            Click_OpenRedactor = new RoutedCommand("Click_OpenRedactor", typeof(MainWindow));
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }

        public static RoutedCommand Click_OpenApp { get; set; }
        public static RoutedCommand Click_OpenRedactor { get; set; }
        public static RoutedCommand Exit { get; set; }
        
    }
}
