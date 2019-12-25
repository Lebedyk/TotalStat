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
            OpenWindow = new RoutedCommand("OpenWindow", typeof(MainWindow));           
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }

        public static RoutedCommand OpenWindow { get; set; }       
        public static RoutedCommand Exit { get; set; }
        
    }
}
