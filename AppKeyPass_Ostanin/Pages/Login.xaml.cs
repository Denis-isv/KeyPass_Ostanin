using AppKeyPass_Ostanin.Contexts;
using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin.Pages
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string token = await UserContext.Login(tbLogin.Text, tbPassword.Password);

            if (!string.IsNullOrEmpty(token))
            {
                MainWindow.Token = token;
                MainWindow.init.OpenPages(new Pages.Main());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}