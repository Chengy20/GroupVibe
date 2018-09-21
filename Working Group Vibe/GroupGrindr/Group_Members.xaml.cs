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
            List<string> memberNames = GlobalVariables.returnNamesGroup(GlobalVariables.selectedGroup);
            if (memberNames.Count > 6)
            {
                Members_Backbar.SetValue(Grid.RowSpanProperty, 6);
                Rectangle secondLayer = new Rectangle();
                secondLayer.SetValue(Grid.RowProperty, 1);
                secondLayer.SetValue(Grid.ColumnProperty, 3);
                secondLayer.SetValue(Grid.RowSpanProperty, memberNames.Count - 6);
                secondLayer.Fill = new SolidColorBrush(Colors.White);

                MainGrid.Children.Add(secondLayer);
                setNames(memberNames, 2, 6);
                setNames(memberNames, 3, memberNames.Count - 6);
            }
            else
            {
                Members_Backbar.SetValue(Grid.RowSpanProperty, memberNames.Count);
                setNames(memberNames, 2, memberNames.Count);
            }
        }

        public void setNames(List<string> Names, int column, int rowspan)
        {
            for (var i = 0; i < rowspan; i++)
            {
                TextBlock newT = new TextBlock();
                newT.SetValue(Grid.RowProperty, i + 1);
                newT.SetValue(Grid.ColumnProperty, column);
                newT.HorizontalAlignment = HorizontalAlignment.Center;
                newT.VerticalAlignment = VerticalAlignment.Center;
                newT.FontSize = 20;
                if (column == 2)
                {
                    newT.Text = Names[i];
                }
                else
                {
                    newT.Text = Names[i + 6];
                }
                MainGrid.Children.Add(newT);
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

        }

        private void Profile_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
