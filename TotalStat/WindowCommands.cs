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

            Data_FileDialog = new RoutedCommand("Data_FileDialog", typeof(RedactorWindow));
            Data_Remove = new RoutedCommand("Data_Remove", typeof(RedactorWindow));
            Data_Refresh = new RoutedCommand("Data_Refresh", typeof(RedactorWindow));
            Data_DeleteDate = new RoutedCommand("Data_DeleteDate", typeof(RedactorWindow));
            Data_AddData = new RoutedCommand("Data_AddData", typeof(RedactorWindow));

            Finviz_FileDialog = new RoutedCommand("Finviz_FileDialog", typeof(RedactorWindow));
            Finviz_Refresh = new RoutedCommand("Finviz_Refresh", typeof(RedactorWindow));

            About_FileDialog = new RoutedCommand("About_FileDialog", typeof(RedactorWindow));
            About_Refresh = new RoutedCommand("About_Refresh", typeof(RedactorWindow));

            Report_FileDialog = new RoutedCommand("Report_FileDialog", typeof(RedactorWindow));
            Report_Refresh = new RoutedCommand("Report_Refresh", typeof(RedactorWindow));
            Report_AddReport = new RoutedCommand("Report_AddReport", typeof(RedactorWindow));
            Report_DeleteDate = new RoutedCommand("Report_DeleteDate", typeof(RedactorWindow));

            Dividend_FileDialog = new RoutedCommand("Dividend_FileDialog", typeof(RedactorWindow));
            Dividend_Refresh = new RoutedCommand("Dividend_Refresh", typeof(RedactorWindow));
            Dividend_AddDiv = new RoutedCommand("Dividend_AddDiv", typeof(RedactorWindow));
            Dividend_DeleteDate = new RoutedCommand("Dividend_DeleteDate", typeof(RedactorWindow));
        }

        public static RoutedCommand OpenWindow { get; set; }       
        public static RoutedCommand Exit { get; set; }

        public static RoutedCommand Data_FileDialog { get; set; }
        public static RoutedCommand Data_Remove { get; set; }
        public static RoutedCommand Data_Refresh { get; set; }
        public static RoutedCommand Data_DeleteDate { get; set; }
        public static RoutedCommand Data_AddData { get; set; }

        public static RoutedCommand Finviz_FileDialog { get; set; }
        public static RoutedCommand Finviz_Refresh { get; set; }


        public static RoutedCommand About_FileDialog { get; set; }
        public static RoutedCommand About_Refresh { get; set; }

        public static RoutedCommand Report_FileDialog { get; set; }
        public static RoutedCommand Report_Refresh { get; set; }
        public static RoutedCommand Report_AddReport { get; set; }
        public static RoutedCommand Report_DeleteDate { get; set; }

        public static RoutedCommand Dividend_FileDialog { get; set; }
        public static RoutedCommand Dividend_Refresh { get; set; }
        public static RoutedCommand Dividend_AddDiv { get; set; }
        public static RoutedCommand Dividend_DeleteDate { get; set; }

    }
}
