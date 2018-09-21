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
    /// Interaction logic for Create_Group_Page.xaml
    /// </summary>
    /// 
    public static class DisplayUsernamesData
    {
        public static int STARTING_COLUMN = 7;
        public static int TOTAL_USERNAMES = 0;
    }
    public partial class Create_Group_Page : Page
    {
        public Create_Group_Page()
        {
            GlobalVariables.connectToDatabase();
            InitializeComponent();
        }

        private void Add_User_Confirm_Click(object sender, RoutedEventArgs e)
        {
            string username = Add_User_Name.Text;

            Group_Members.Text = Group_Members.Text + username + Environment.NewLine;

            Add_User_Name.Text = "";
            /*
            TextBlock displayName = new TextBlock();
            displayName.Text = username;
            displayName.SetValue(Grid.ColumnProperty, 3);
            displayName.SetValue(Grid.RowProperty, DisplayUsernamesData.STARTING_COLUMN + DisplayUsernamesData.TOTAL_USERNAMES);

            MainGrid.Children.Add(displayName);
            Add_User_Name.Text = "";
            DisplayUsernamesData.TOTAL_USERNAMES++;
            */
        }

        private void Confirm_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            GlobalGroupStorage.TOTAL_GROUPS++;
            GlobalGroupStorage.GroupNames.Add(Group_Name.Text);
            GlobalGroupStorage.GroupIDs.Add(Group_ID.Text);
            GlobalGroupStorage.GroupDescriptions.Add(Group_Description.Text);

            GlobalVariables.insertIntoGroup(Group_Name.Text, "#FFAA20", Group_Description.Text);

            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Details nextPage = new Group_Details();
            navService.Navigate(nextPage);
        }
    }

}
