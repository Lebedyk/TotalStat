using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace TotalStat
{
    public class SetDataGridColorConverter : IValueConverter
    {
        public SolidColorBrush DarkRedBrush {get;set;}
        public SolidColorBrush DarkGreenBrush { get; set; }

        public SolidColorBrush BlackBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value > 0)
            {
                return DarkGreenBrush;
            }
            else return (double)value < 0 ? DarkRedBrush : BlackBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => 
                                                                                             throw new NotImplementedException();
    }

    public class ReportShowConverter : IValueConverter
    {
        public SolidColorBrush DarkRedBrush { get; set; }
        public SolidColorBrush DarkGreenBrush { get; set; }
        public SolidColorBrush DarkBlueBrush { get; set; }
        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == Localize.YestAC || value.ToString() == Localize.TodayBO)
            {
                return DarkRedBrush;
            }                
            else if ((value.ToString() == Localize.DayBeforeYestBO) || (value.ToString() == Localize.DayBeforeYestAC) 
                    || (value.ToString() == Localize.YestBO))
            {
                return DarkBlueBrush;
            }                
            else if((value.ToString() == Localize.TodayAC) || (value.ToString() == Localize.TomorrowBO) 
                    || (value.ToString() == Localize.TomorrowAC))
            {
                return DarkGreenBrush;
            }
            else
            {
                return DefaultBrush;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => 
                                                                                            throw new NotImplementedException();
    }

    public class DividendShowConverter : IValueConverter
    {        
        public SolidColorBrush BlackBrush { get; set; }
        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() != "" ? BlackBrush : DefaultBrush;            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => 
                                                                                throw new NotImplementedException();
    }

    public class ReportInSectorConverter : IValueConverter
    {
        public SolidColorBrush DarkRedBrush { get; set; }
        public SolidColorBrush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)        
        {            
            var ololo = AppWindowViewModel.ActualReports.FirstOrDefault(p => p.Ticker == value.ToString());
            return ololo != null ? DarkRedBrush : DefaultBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => 
                                                                                throw new NotImplementedException();
    }
}
