﻿using System;
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
using System.Windows.Shapes;

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
            this.Closed += RedactorWindow_Closed;
        }
        private void RedactorWindow_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }

    }
}
