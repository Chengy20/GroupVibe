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
    /// Interaction logic for Account_Details.xaml
    /// </summary>
    public partial class Account_Details : Page
    {
        public Account_Details()
        {
            InitializeComponent();
            GlobalVariables.connectToDatabase();
        }

        private void CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Create_Group_Page nextPage = new Create_Group_Page();
            navService.Navigate(nextPage);
        }

        private void MyGroups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Groups_Page nextPage = new Groups_Page();
            navService.Navigate(nextPage);
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string UserFirstName = GlobalVariables.currentPerson.FName;
            string UserLastName = GlobalVariables.currentPerson.LName;
            string UserCode = GlobalVariables.currentPerson.Email;
            string UserName = GlobalVariables.currentPerson.Username;
            FN.Text = UserFirstName;
            LN.Text = UserLastName;
            UC.Text = UserCode;
            UN.Text = UserName;

        }
    }
}
