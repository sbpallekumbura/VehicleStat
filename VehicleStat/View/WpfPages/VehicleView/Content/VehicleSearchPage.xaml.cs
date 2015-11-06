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


namespace View.WpfPages.VehicleView.Content
{
    /// <summary>
    /// Interaction logic for Employee QuickSearchPage.xaml
    /// </summary>
    public partial class VehicleSearchPage : Page, INotifyPropertyChanged
    {
        private static VehicleSearchPage _instance;
        private string _searchText;

        public event PropertyChangedEventHandler PropertyChanged;

        private List<vehicle> VehicleList;

        public List<PageData> PagingList { get; set; }
        private PagingCollection<vehicle> _PagingCollection { get; set; }

        private VehicleSearchPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static VehicleSearchPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleSearchPage();
                }
                return _instance;
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private void RefreshVehicleListByPage(int page)
        {
            _PagingCollection = VehicleService.GetSearchedVehicleListByPage(page,_searchText);

            VehicleList = _PagingCollection.Collection;
            PagingList = _PagingCollection.PagesList;

            SearchedVehicleListView.ItemsSource = VehicleList;
            SearchedVehicleListView.Items.Refresh();

            PagingListView.ItemsSource = PagingList;
            PagingListView.Items.Refresh();
        }

        private void QuickSearchButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshVehicleListByPage(1);
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
