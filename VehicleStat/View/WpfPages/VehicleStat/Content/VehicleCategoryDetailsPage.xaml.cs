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
            LoadBarChartData(SearchKey);
        }
        private void LoadBarChartData(string key)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                List<tbl_search_key> searchDetails1 = VehicleStatService.GetSearchKeyDetailsAsList(key, 2013);
                List<tbl_search_key> searchDetails2 = VehicleStatService.GetSearchKeyDetailsAsList(key, 2014);

                Dispatcher.Invoke((Action)(() => ccChart.Series[0].ItemsSource = searchDetails1));
                Dispatcher.Invoke((Action)(() => ccChart.Series[1].ItemsSource = searchDetails2));
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                //work has completed. you can now interact with the UI
                VehicleCategoryDetailsPage.Instance.BusyBar.IsBusy = false;
            };
            //set the IsBusy before you start the thread
            VehicleCategoryDetailsPage.Instance.BusyBar.IsBusy = true;
            worker.RunWorkerAsync();
        }

        private void MakeGraphsEvent(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                List<tbl_search_key> searchDetails1 = VehicleStatService.GetSearchKeyDetailsAsList("diesel/petrol", 2013);
                List<tbl_search_key> searchDetails2 = VehicleStatService.GetSearchKeyDetailsAsList("diesel/petrol", 2014);

                List<tbl_search_key> searchDetails3 = VehicleStatService.GetSearchKeyDetailsAsList("Urban/Non-Urban", 2013);
                List<tbl_search_key> searchDetails4 = VehicleStatService.GetSearchKeyDetailsAsList("Urban/Non-Urban", 2014);

                List<tbl_search_key> searchDetails5 = VehicleStatService.GetSearchKeyDetailsAsList("Car/Van", 2013);
                List<tbl_search_key> searchDetails6 = VehicleStatService.GetSearchKeyDetailsAsList("Car/Van", 2014);

                Dispatcher.Invoke((Action)(() => mcChart1.Series[0].ItemsSource = searchDetails1));
                Dispatcher.Invoke((Action)(() => mcChart2.Series[0].ItemsSource = searchDetails2));
                Dispatcher.Invoke((Action)(() => mcChart3.Series[0].ItemsSource = searchDetails3));
                Dispatcher.Invoke((Action)(() => mcChart4.Series[0].ItemsSource = searchDetails4));
                Dispatcher.Invoke((Action)(() => mcChart5.Series[0].ItemsSource = searchDetails5));
                Dispatcher.Invoke((Action)(() => mcChart6.Series[0].ItemsSource = searchDetails6));
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                //work has completed. you can now interact with the UI
                VehicleCategoryDetailsPage.Instance.BusyBar1.IsBusy = false;
            };
            //set the IsBusy before you start the thread
            VehicleCategoryDetailsPage.Instance.BusyBar1.IsBusy = true;
            worker.RunWorkerAsync();
        }

        private List<tbl_search_key> KeyIndexList;

        public List<PageData> PagingList { get; set; }
        private PagingCollection<tbl_search_key> _PagingCollection { get; set; }

        private void RefreshKeyIndexListByPage(int page)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                _PagingCollection = VehicleStatService.GetKeyIndexListByPage(page);
                KeyIndexList = _PagingCollection.Collection;
                PagingList = _PagingCollection.PagesList;
                Dispatcher.Invoke((Action)(() => KeyIndexListView.ItemsSource = KeyIndexList));
                Dispatcher.Invoke((Action)(() => KeyIndexListView.Items.Refresh()));
                Dispatcher.Invoke((Action)(() => PagingListView.ItemsSource = PagingList));
                Dispatcher.Invoke((Action)(() => PagingListView.Items.Refresh()));
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                //work has completed. you can now interact with the UI
                VehicleCategoryDetailsPage.Instance.BusyBar2.IsBusy = false;
            };
            //set the IsBusy before you start the thread
            VehicleCategoryDetailsPage.Instance.BusyBar2.IsBusy = true;
            worker.RunWorkerAsync();
        }

        private void PaginationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int selectedpage = int.Parse(button.Content.ToString());

            RefreshKeyIndexListByPage(selectedpage);
        }

        private void TabItem_Loaded_1(object sender, RoutedEventArgs e)
        {
            RefreshKeyIndexListByPage(1);
        }
        
    }
}
