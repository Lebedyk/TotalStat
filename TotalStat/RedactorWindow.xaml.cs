using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for RedactorWindow.xaml
    /// </summary>
    public partial class RedactorWindow : Window
    {       
        public RedactorWindow()
        {
            InitializeComponent();
            this.Closed += RedactorWindowClosed;            
            DataContext = new RedactorWindowViewModel();
        }
        private void RedactorWindowClosed(object sender, EventArgs e)
        {            
            App.Current.MainWindow.Visibility = Visibility.Visible;
            AppSizeGeometry.SaveSizeAndGeometry();
        }
        
    }
}
