using System;
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

namespace VehicleStat.View.WpfPages.DashBoard
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page
    {
        private static DashBoard _instance=null;

        private DashBoard()
        {
            InitializeComponent();
        }

        public static DashBoard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DashBoard();
                }
                return _instance;
            }
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
