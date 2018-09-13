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
    /// Interaction logic for Groups_Page.xaml
    /// </summary>
    public partial class Groups_Page : Page
    {

        public Groups_Page()
        {
            GlobalVariables.connectToDatabase();
            InitializeComponent();
        }
        private void MyGroups_Click(object sender, RoutedEventArgs e)
        {
            List<string> groups = GlobalVariables.returnListGroups();
            int totalGroups = groups.Count;
            int currentRow = 1;
            int currentColumn = 1;
            for(var i = 0; i < totalGroups; i++)
            {
                Button newGroup = new Button();
                newGroup.Content = groups[i];
                newGroup.SetValue(Grid.ColumnProperty, currentColumn);
                newGroup.SetValue(Grid.RowProperty, currentRow);
                newGroup.Click += new RoutedEventHandler(newGroup_ButtonClick);

                MainGrid.Children.Add(newGroup);
                if (i % 3 == 0 && i != 0)
                {
                    currentRow++;
                    currentColumn = 1;
                }
                else
                {
                    currentColumn++;
                }

            }
        }
        private void newGroup_ButtonClick(object sender, RoutedEventArgs e)
        {
            // don't need to check if it in it since we already clicked on it
            // gets the name of the button
            string name = "";
            for (int i = 32; i < sender.ToString().Length; i++)
            {
                name += sender.ToString()[i];
            }

            GlobalVariables.selectedGroup = GlobalVariables.returnGroupIDfromName(name);
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Details nextPage = new Group_Details();
            navService.Navigate(nextPage);
        }

        private void CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Create_Group_Page nextPage = new Create_Group_Page();
            navService.Navigate(nextPage);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Groups_Page nextPage = new Groups_Page();
            navService.Navigate(nextPage);
        }
    }
}
