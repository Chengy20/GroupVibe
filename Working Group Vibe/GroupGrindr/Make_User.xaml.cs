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
using System.Text.RegularExpressions;

namespace GroupGrindr
{
    /// <summary>
    /// Interaction logic for Make_User.xaml
    /// </summary>.P
    public partial class Make_User : Page
    {
        public Make_User()
        {
            InitializeComponent();
            GlobalVariables.connectToDatabase();
        }

        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Login.xaml", UriKind.Relative));
        }

        private void MakeUserNow(object sender, RoutedEventArgs e)
        {
            bool Robbieisbudgesbestfriend = false;
            string StringAlpha = UserEnteredName.Text;
            bool HasSpace = StringAlpha.Contains(" ");
            string UserNameNow = UserEnteredName.Text.ToString();

            bool FirstNameContainsSpace = UserFirstName.Text.Contains(" ");
            bool LastNameContainsSpace = UserLastName.Text.Contains(" ");

            bool FirstNameContainsWrong = false;
            bool LastNameContainsWrong = false;

            if (UserFirstName.Text.Contains("\u0022")) { LastNameContainsWrong = true; }
            if (UserLastName.Text.Contains("\u0022")) { LastNameContainsWrong = true; }
            if (UserFirstName.Text.Contains("\u0027")) { LastNameContainsWrong = true; }
            if (UserLastName.Text.Contains("\u0027")) { LastNameContainsWrong = true; }

            if (UserEnteredCode.Text.Contains("\u0022")) { LastNameContainsWrong = true; }
            if (PasswordBoxConfirm.Password.Contains("\u0022")) { LastNameContainsWrong = true; }
            if (UserEnteredCode.Text.Contains("\u0027")) { LastNameContainsWrong = true; }
            if (PasswordBoxMake.Password.Contains("\u0027")) { LastNameContainsWrong = true; }
            if (PasswordBoxConfirm.Password.Contains("\u0027")) { LastNameContainsWrong = true; }
            if (PasswordBoxConfirm.Password.Contains("\u0022")) { LastNameContainsWrong = true; }



            if (UserFirstName.Text.Length < 2 || UserLastName.Text.Length < 2)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "First or Last Name Too Short!";
                Robbieisbudgesbestfriend = true;
            }
            if (FirstNameContainsSpace || LastNameContainsSpace)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "First or Last Name Contains A Space!";
                Robbieisbudgesbestfriend = true;
            }
            if (FirstNameContainsWrong || LastNameContainsWrong)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "Please Do Not Use \" or \'";
                Robbieisbudgesbestfriend = true;
            }

            /*
            if (PasswordBoxConfirm.Password == PasswordBoxMake.Password && UserEnteredName.Text != "User Name" && HasSpace == false)
            {
                var NewPassword = PasswordBoxConfirm.Password;
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#3dff11") as SolidColorBrush;
                ErrorBox.Text = "User Created!";
                //add password to data base
            }
            */

            if (UserEnteredName.Text == "User Name" || HasSpace || UserEnteredName.Text.Length < 5 || (UserNameNow.Contains('\u0022')) || (UserNameNow.Contains('\u0027')))
            {
                if (HasSpace) {
                    ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                    ErrorBox.Text = "User Name Has Spaces!";
                }
                else if (UserEnteredName.Text.Length < 5)
                {
                    ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                    ErrorBox.Text = "User Name To Short!";
                }
                else
                {
                    ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                    ErrorBox.Text = "User Name Invalid";
                }
                Robbieisbudgesbestfriend = true;
            }

            if (PasswordBoxConfirm.Password != PasswordBoxMake.Password) {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "Passwords Do Not Match!";
                Robbieisbudgesbestfriend = true;
            }
            if (UserEnteredName.Text == "User Name" || HasSpace)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "User Name Invalid!";
                Robbieisbudgesbestfriend = true;
            }
            if (PasswordBoxMake.Password == PasswordBoxConfirm.Password && PasswordBoxMake.Password.Length < 5)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "Password To Short!";
                Robbieisbudgesbestfriend = true;
            }

            if (PasswordBoxMake.Password.Any(char.IsUpper))
            {

            }
            else
            {

                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "Password Doesn't Meet Requirements!";
            }


            // Zachary's tests

            if (GlobalVariables.isEmailInPeople(UserEnteredCode.Text)) {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "Student Code is already taken!";
                Robbieisbudgesbestfriend = true;
            }

            if (GlobalVariables.isUsernameInPeople(UserEnteredName.Text)) {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#ff0000") as SolidColorBrush;
                ErrorBox.Text = "Username is already taken!";
                Robbieisbudgesbestfriend = true;
            }
 

            // End of Zac's tests
            if (Robbieisbudgesbestfriend == false)
            {
                ErrorBox.Foreground = new BrushConverter().ConvertFromString("#3dff11") as SolidColorBrush;
                ErrorBox.Text = "User Created!";
                PublishUser.Visibility = Visibility.Hidden;
                Go_Login.Content = "Go To Login";
                GlobalVariables.insertIntoPeople(UserFirstName.Text,UserLastName.Text, PasswordBoxConfirm.Password, int.Parse(UserEnteredCode.Text), UserEnteredName.Text);
            }


        }
        private void Event(object sender, KeyEventArgs e)
        {
            if (!Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                ErrorBox.Text = "Letters Only!";
            }

        }

        private void Scode(object sender, KeyEventArgs e)
        {
            if (!Char.IsNumber((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
                {
                    e.Handled = true;
                    ErrorBox.Text = "Numbers Only!";
                }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LastName_Box(object sender, RoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}

