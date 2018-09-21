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
    /// Interaction logic for Group_Tasks.xaml
    /// </summary>
    public partial class Group_Tasks : Page
    {
        public Group_Tasks()
        {
            GlobalVariables.connectToDatabase();
            InitializeComponent();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Groups_Page nextPage = new Groups_Page();
            navService.Navigate(nextPage);
        }

        private void Files_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Files nextPage = new Group_Files();
            navService.Navigate(nextPage);
        }

        private void Members_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Members nextPage = new Group_Members();
            navService.Navigate(nextPage);
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Tasks nextPage = new Group_Tasks();
            navService.Navigate(nextPage);
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            Group_Details nextPage = new Group_Details();
            navService.Navigate(nextPage);
        }

        private void GetDate(object sender, RoutedEventArgs e)
        {
            foreach (DateTime date in Task_Calendar.SelectedDates)
            {
                EventDetails.IsOpen = true;

                DisplayTasks.Text = DisplayTasks.Text + date.ToShortDateString();
                Date.Text = date.ToShortDateString();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Description_Box(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Create_Task(object sender, RoutedEventArgs e)
        {
            DisplayTasks.Text = DisplayTasks.Text + Environment.NewLine + TaskName.Text + Environment.NewLine + TaskDescription.Text + Environment.NewLine;
        }
    }
}
