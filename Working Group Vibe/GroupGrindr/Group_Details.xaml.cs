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
    /// Interaction logic for Group_Details.xaml
    /// </summary>
    public partial class Group_Details : Page
    {
        public Group_Details()
        {
            GlobalVariables.connectToDatabase();
            InitializeComponent();
            load_Page();
        }

        private void load_Page()
        {
            //Group_Name_Text,Group_ID_Text,Group_Description_Text

            List<string> group = GlobalVariables.returnGroupInfo(GlobalVariables.selectedGroup);
            Group_Name_Text.Text = group[0];
            Group_ID_Text.Text = group[1];
            Group_Description_Text.Text = group[2];
        }

        private void GroupDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyGroups_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Members_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Members nextPage = new Group_Members();
            navService.Navigate(nextPage);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Groups_Page nextPage = new Groups_Page();
            navService.Navigate(nextPage);
        }

        private void Tasks_Click_1(object sender, RoutedEventArgs e)
        {

            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Tasks nextPage = new Group_Tasks();
            navService.Navigate(nextPage);

        }

        private void Files_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Details nextPage = new Group_Details();
            navService.Navigate(nextPage);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
