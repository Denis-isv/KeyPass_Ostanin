using System.Windows;
using System.Windows.Controls;
using AppKeyPass_Ostanin.Contexts;

namespace AppKeyPass_Ostanin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        public async Task Auth(string login, string password)
        {
            string? Token = await UserContext.Login(login, password);
            if (Token == null)
            {
                MessageBox.Show("Бро ты не попал...");
            }
            else
            {
                MainWindow.Token = Token;
                MainWindow.init.OpenPages(new Pages.Main());
            }
        }
        private async void BtnAuth(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Укажите логин: ");
            }
            if (string.IsNullOrEmpty(tbPassword.Password))
            {
                MessageBox.Show("Укажите пароль:");
            }
            await Auth(tbLogin.Text, tbPassword.Password);
        }
    }
}
