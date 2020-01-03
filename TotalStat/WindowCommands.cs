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
            FileDialog = new RoutedCommand("FileDialog", typeof(RedactorWindow));
            Remove = new RoutedCommand("Remove", typeof(RedactorWindow));
            Refresh = new RoutedCommand("Refresh", typeof(RedactorWindow));
            DeleteDate = new RoutedCommand("DeleteDate", typeof(RedactorWindow));
        }

        public static RoutedCommand OpenWindow { get; set; }       
        public static RoutedCommand Exit { get; set; }
        public static RoutedCommand FileDialog { get; set; }
        public static RoutedCommand Remove { get; set; }
        public static RoutedCommand Refresh { get; set; }        
        public static RoutedCommand DeleteDate { get; set; }

    }
}
