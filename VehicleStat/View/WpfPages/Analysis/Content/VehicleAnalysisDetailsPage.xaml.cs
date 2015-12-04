using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System;
using Util.GUI;
using VehicleStat.Data.DBModel;
using DBService.Implementions;
using View.WpfWindows;
using System.Windows.Controls.DataVisualization.Charting;
using VehicleStat.Data.DBService.Implementions;
using System.Threading;


namespace View.WpfPages.Analysis.Content
{
    /// <summary>
    /// Interaction logic for Employee QuickSearchPage.xaml
    /// </summary>
    public partial class VehicleAnalysisDetailsPage : Page, INotifyPropertyChanged
    {
        private static VehicleAnalysisDetailsPage _instance;

        public event PropertyChangedEventHandler PropertyChanged;
        private string _searchKey;
        private string _year;

        private VehicleAnalysisDetailsPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static VehicleAnalysisDetailsPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleAnalysisDetailsPage();
                }
                return _instance;
            }
        }
      

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }   

    }
}
