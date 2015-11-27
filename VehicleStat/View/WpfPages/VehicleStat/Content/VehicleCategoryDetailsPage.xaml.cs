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


namespace View.WpfPages.VehicleStat.Content
{
    /// <summary>
    /// Interaction logic for Employee QuickSearchPage.xaml
    /// </summary>
    public partial class VehicleCategoryDetailsPage : Page, INotifyPropertyChanged
    {
        private static VehicleCategoryDetailsPage _instance;

        public event PropertyChangedEventHandler PropertyChanged;
        private string _searchKey;
        private string _year;

        private VehicleCategoryDetailsPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static VehicleCategoryDetailsPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleCategoryDetailsPage();
                }
                return _instance;
            }
        }
        public string SearchKey
        {
            get
            {
                return _searchKey;
            }
            set
            {
                _searchKey = value;
                OnPropertyChanged("SearchKey");
            }
        }

        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
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

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            LoadBarChartData(SearchKey,Int32.Parse(Year));
        }
        private void LoadBarChartData(string key,int year)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                //KeyValuePair<string, Nullable<int>>[] searchDetails = VehicleStatService.GetSearchKeyDetails(key, year);
                List<tbl_search_key> searchDetails = VehicleStatService.GetSearchKeyDetailsAsList(key, year);
                Dispatcher.Invoke((Action)(() =>((BarSeries)mcChart.Series[0]).ItemsSource=searchDetails ));
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                //work has completed. you can now interact with the UI
                VehicleStatDashBoard.Instance.BusyBar.IsBusy = false;
            };
            //set the IsBusy before you start the thread
            VehicleStatDashBoard.Instance.BusyBar.IsBusy = true;
            worker.RunWorkerAsync();


            //((BarSeries)mcChart.Series[0]).ItemsSource = VehicleStatService.GetSearchKeyDetails(key, year);
            //new KeyValuePair<string, int>[]{
            //    new KeyValuePair<string, int>("Project Manager", 12),
            //    new KeyValuePair<string, int>("CEO", 25),
            //    new KeyValuePair<string, int>("Software Engg.", 5),
            //    new KeyValuePair<string, int>("Team Leader", 6),
            //    new KeyValuePair<string, int>("Project Leader", 10),
            //    new KeyValuePair<string, int>("Developer", 4) };
        }

    }
}
