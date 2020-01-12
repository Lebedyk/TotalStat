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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TotalStat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        } 
        private void OpenWindow_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.OriginalSource == LoadApp)
            {
                AppWindow appwindow = new AppWindow();
                appwindow.Owner = this;
                appwindow.Show();
                this.Visibility = Visibility.Collapsed;
            }
            if(e.OriginalSource == LoadRedactor)
            {
                RedactorWindow redactorwindow = new RedactorWindow();
                redactorwindow.Owner = this;
                redactorwindow.Show();
                this.Visibility = Visibility.Collapsed;
            }            
        }
        private void Exit_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }


    }
    
}