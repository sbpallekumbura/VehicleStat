using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using View.WpfWindows;
using VehicleStat.View.WpfPages.DashBoard;
using View.WpfPages.VehicleStat.Content;
using VehicleStat.View.WpfPages.VehicleStat.Content;

namespace View.WpfPages.VehicleStat
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class VehicleStatDashBoard : Page
    {
        private static VehicleStatDashBoard _instance;


        public VehicleStatDashBoard()
        {
            InitializeComponent();
            ContentFrame.Content = VehicleCategoryDetailsPage.Instance;
        }

        public static VehicleStatDashBoard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleStatDashBoard();
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
