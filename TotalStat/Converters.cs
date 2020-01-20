using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TotalStat
{
    public class SetDataGridColorConverter : IValueConverter
    {
        public SolidColorBrush DarkRedBrush {get;set;}
        public SolidColorBrush DarkGreenBrush { get; set; }

        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value > 0)
                return DarkGreenBrush;
            else if((double)value < 0)
                return DarkRedBrush;
            else
            {
                return DefaultBrush;
            }
        }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReportShowConverter : IValueConverter
    {
        public SolidColorBrush DarkRedBrush { get; set; }
        public SolidColorBrush DarkGreenBrush { get; set; }

        public SolidColorBrush DarkBlueBrush { get; set; }
        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "YAC" || value.ToString() == "ABO")
                return DarkRedBrush;
            else if ((value.ToString() == "YYBO") || (value.ToString() == "YYAC") || (value.ToString() == "YBO"))
                return DarkBlueBrush;
            else if((value.ToString() == "AAC") || (value.ToString() == "TBO") || (value.ToString() == "TAC"))
            {
                return DarkGreenBrush;
            }
            else
            {
                return DefaultBrush;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DividendShowConverter : IValueConverter
    {        
        public SolidColorBrush BlackBrush { get; set; }
        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() != "")
            {
                return BlackBrush;
            }                
            {
                return DefaultBrush;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReportInSectorConverter : IValueConverter
    {
        public SolidColorBrush DarkRedBrush { get; set; }
        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)        
        {            
            var ololo = AppWindow.ActualReports.FirstOrDefault(p => p.Ticker == value.ToString());
            
            if(ololo != null)
            {                
                return DarkRedBrush;
            }
            else
            {
                return DefaultBrush;
            }
        }
            
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
