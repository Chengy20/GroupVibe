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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            GlobalVariables.connectToDatabase();
            //GlobalVariables.insertIntoPeople("Z", "C", "123", 9, "B");
        }

        private void LoginDown(object sender, RoutedEventArgs e)
        {
            var canContinue = true;
            var userPass = true;
            var studentPass = true;
            var password = PasswordBox.Password;

            var user = UserName.Text;
            //Check user in database//// Idk How XD

            if (GlobalVariables.isUsernameInPeople(user) == false)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#3dff11") as SolidColorBrush;
                ErrorBox.Text = "User not found";
                userPass = false;
            }
            if (GlobalVariables.isEmailInPeople(user) == false)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#3dff11") as SolidColorBrush;
                ErrorBox.Text = "Student Code not found";
                studentPass = false;
            }

            if (GlobalVariables.IsDigitsOnly(user))
            {
                if (GlobalVariables.isCorrectPasswordEmail(password, int.Parse(user)) == false)
                {
                    ErrorBox.Foreground = new BrushConverter().ConvertFromString("#3dff11") as SolidColorBrush;
                    ErrorBox.Text = "Incorrect Password";
                    canContinue = false;
                }
            } else
            {
                if (GlobalVariables.isCorrectPasswordUsername(password, user) == false)
                {
                    ErrorBox.Foreground = new BrushConverter().ConvertFromString("#3dff11") as SolidColorBrush;
                    ErrorBox.Text = "Incorrect Password";
                    canContinue = false;
                }
            }



            if (canContinue == true && (userPass || studentPass))
            {
                NavigationService navService = NavigationService.GetNavigationService(this);
                Groups_Page nextPage = new Groups_Page();
                navService.Navigate(nextPage);
            }
        }

        private void Make_User(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Make_User.xaml", UriKind.Relative));
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
