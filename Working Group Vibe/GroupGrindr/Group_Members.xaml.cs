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
    /// Interaction logic for Group_Members.xaml
    /// </summary>
    public partial class Group_Members : Page
    {
        public Group_Members()
        {
            GlobalVariables.connectToDatabase();
            InitializeComponent();

        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Details nextPage = new Group_Details();
            navService.Navigate(nextPage);
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Tasks nextPage = new Group_Tasks();
            navService.Navigate(nextPage);
            
        }
        private void Members_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Members nextPage = new Group_Members();
            navService.Navigate(nextPage);
        }

        private void Files_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Files nextPage = new Group_Files();
            navService.Navigate(nextPage);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Groups_Page nextPage = new Groups_Page();
            navService.Navigate(nextPage);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
