using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    /// 
    public partial class AppWindow : Window
    {
        public AppWindow()
        {            
            InitializeComponent();
            DataContext = new AppWindowViewModel();
            this.Closed += AppWindow_Closed;
        }        
        private void AppWindow_Closed(object sender, EventArgs e)
        {            
            App.Current.MainWindow.Visibility = Visibility.Visible;
            AppSizeGeometry.SaveSizeAndGeometry();            
        }        
    }    
}
