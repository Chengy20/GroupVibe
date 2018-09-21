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
        public static int TOTAL_USERNAMES;
        public static List<string> NAMES_IN;
    }
    public partial class Create_Group_Page : Page
    {
        public Create_Group_Page()
        {
            GlobalVariables.connectToDatabase();
            InitializeComponent();
            resetData();
            addSelfUser();
        }

        private void addSelfUser()
        {
            string username = GlobalVariables.currentPerson.Email;
            Group_Members.Text = Group_Members.Text + $"{GlobalVariables.returnName(username)} ({username})" + Environment.NewLine;

            Add_User_Name.Text = "";
            DisplayUsernamesData.TOTAL_USERNAMES++;
            DisplayUsernamesData.NAMES_IN.Add(username);
        }

        private void resetData()
        {
            DisplayUsernamesData.TOTAL_USERNAMES = 0;
            DisplayUsernamesData.NAMES_IN = new List<string>();
        }

        private void Add_User_Confirm_Click(object sender, RoutedEventArgs e)
        {
            // username is email
            string username = Add_User_Name.Text;

            if (GlobalVariables.isEmailInPeople(username))
            {
                if (!DisplayUsernamesData.NAMES_IN.Contains(username))
                {
                    Group_Members.Text = Group_Members.Text + $"{GlobalVariables.returnName(username)} ({username})" + Environment.NewLine;

                    Add_User_Name.Text = "";
                    DisplayUsernamesData.TOTAL_USERNAMES++;
                    DisplayUsernamesData.NAMES_IN.Add(username);
                }
                else
                {
                    MessageBox.Show("User is already added to group");
                }
            }
            else
            {
                MessageBox.Show("User is not in database!");
            }
        }

        private void Confirm_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            // Add a colour wheel or something
            if (Group_Name.Text == "")
            {
                MessageBox.Show("A group name is required");
            }
            else if (Group_Description.Text == "")
            {
                MessageBox.Show("A description is required");
            }
            else
            {
                GlobalGroupStorage.TOTAL_GROUPS++;
                GlobalGroupStorage.GroupNames.Add(Group_Name.Text);
                GlobalGroupStorage.GroupIDs.Add(Group_ID.Text);
                GlobalGroupStorage.GroupDescriptions.Add(Group_Description.Text);

                GlobalVariables.insertIntoGroup(Group_Name.Text, "#FFAA20", Group_Description.Text);

                int groupID = GlobalVariables.returnAmountOfGroups();

                foreach (string email in DisplayUsernamesData.NAMES_IN)
                {
                    GlobalVariables.insertPersonIntoGroup(GlobalVariables.emailToID(email), groupID);
                }

                NavigationService navService = NavigationService.GetNavigationService(this);
                Groups_Page nextPage = new Groups_Page();
                navService.Navigate(nextPage);
            }
        }
    }

}
