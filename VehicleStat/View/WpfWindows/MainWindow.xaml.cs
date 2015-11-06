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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using VehicleStat.View.WpfPages.DashBoard;

namespace View.WpfWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static MainWindow _instance=null;

        private MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = DashBoard.Instance;
        }

        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainWindow();
                }
                return _instance;
            }
        }

        private bool? ShouldClose = null;

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ShouldClose == null)
            {
                e.Cancel = true; //stop the window from closing.
                MessageDialogResult result = await this.ShowMessageAsync(this.Title, "Do You really want to exit?", MessageDialogStyle.AffirmativeAndNegative);
                if (result == MessageDialogResult.Negative)
                {
                    ShouldClose = false;
                }
                else
                {
                    ShouldClose = true;
                    Application.Current.Shutdown();
                }
            }
            else if (!(bool)ShouldClose)
            {
                e.Cancel = true; //prevent the window from closing.

            }
            ShouldClose = null;
        }
    }
}
