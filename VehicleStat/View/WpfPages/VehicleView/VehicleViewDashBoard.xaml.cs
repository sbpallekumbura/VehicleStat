﻿using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using View.WpfPages.VehicleView.Content;
using VehicleStat.View.WpfPages.DashBoard;
using View.WpfWindows;

namespace View.WpfPages.VehicleView
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class VehicleViewDashBoard : Page
    {
        private static VehicleViewDashBoard _instance;


        public VehicleViewDashBoard()
        {
            InitializeComponent();
            ContentFrame.Content = VehicleSearchPage.Instance;
        }

        public static VehicleViewDashBoard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleViewDashBoard();
                }
                return _instance;
            }
        }

        private void backButtonEvent(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ContentFrame.Content = DashBoard.Instance;
        }
    }
       
}
