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
            List<string> memberNames = GlobalVariables.returnNamesGroupForMembers(GlobalVariables.selectedGroup);
            DisplayTasks.Text = "USER IDs IN THIS GROUP                                                     " + Environment.NewLine + Environment.NewLine;
            for (var i = 0; i < memberNames.Count; i++)
            {
                DisplayTasks.Text = DisplayTasks.Text + Environment.NewLine + memberNames[i] + Environment.NewLine + Environment.NewLine;
            }

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
            NavigationService navService = NavigationService.GetNavigationService(this);
            Account_Details nextPage = new Account_Details();
            navService.Navigate(nextPage);
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

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            bool isDigitsOnly = true;
            foreach(char c in AddedUsername.Text)
            {
                if(!(c < '0' || c >'9'))
                {
                    isDigitsOnly = false;
                }
            }
            if (isDigitsOnly)
            {
                UserAddedText.Text = "Error! Please enter number ID of user!";
            }else if (GlobalVariables.userInGroup(GlobalVariables.emailToID(AddedUsername.Text), GlobalVariables.selectedGroup)){
                UserAddedText.Text = "Error! User already in group!";
            }else if(GlobalVariables.userInDatabase(Convert.ToInt32(AddedUsername.Text)))
            {
                UserAddedText.Text = AddedUsername.Text + " Added!";
                GlobalVariables.insertPersonIntoGroup(Convert.ToInt32(AddedUsername.Text), GlobalVariables.selectedGroup);
            }
            else
            {
                UserAddedText.Text = AddedUsername.Text + " is not in database.";
            }

            AddedUsername.Text = "";
            UserAddedText.Visibility = Visibility.Visible;

        }
    }
}



