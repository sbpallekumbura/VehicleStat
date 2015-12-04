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
using View.WpfPages.Analysis.Content;

namespace View.WpfPages.Analysis
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class VehicleAnalysisDashBoard : Page
    {
        private static VehicleAnalysisDashBoard _instance;


        public VehicleAnalysisDashBoard()
        {
            InitializeComponent();
            ContentFrame.Content = VehicleAnalysisDetailsPage.Instance;
        }

        public static VehicleAnalysisDashBoard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleAnalysisDashBoard();
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
