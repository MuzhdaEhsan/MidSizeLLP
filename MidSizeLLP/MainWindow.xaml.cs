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

namespace MidSizeLLP
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
        //If the selection is changed, load the appropriate custom user control.
        private void SettingsListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = e.Source as ListView;

            if (listView != null)
            {
                SettingsContentPanel.Children.Clear();

                if (listView.SelectedItem.Equals(LendOut))
                {
                    //AddCar is a custom user control (WPF), I added it by right clicking on the project and adding an item.
                    Control controlAddCar = new LendOut();
                    //Settings Content Panel is the grid in our MainWindow.xaml.
                    this.SettingsContentPanel.Children.Add(controlAddCar);

                }
                if (listView.SelectedItem.Equals(ViewLendOut))
                {
                    //ViewCArInventory is a custom user control (WPF), I added it by right clicking on the project and adding an item.
                    Control controlViewCar = new ViewLendOut();
                    this.SettingsContentPanel.Children.Add(controlViewCar);
                }
            }
        }
    }
}
