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

namespace GroupGrindr
{
    /// <summary>
    /// Interaction logic for leave_group.xaml
    /// </summary>
    public partial class leave_group : Page
    {
        public leave_group()
        {
            InitializeComponent();
        }

        private void Leave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to leave this group?", "Leave Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                GlobalVariables.leaveGroup();

                NavigationService navService = NavigationService.GetNavigationService(this);
                Groups_Page nextPage = new Groups_Page();
                navService.Navigate(nextPage);
            }
        }
    }
}
