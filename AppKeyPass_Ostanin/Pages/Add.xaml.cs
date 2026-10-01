using AppKeyPass_Ostanin.Contexts;
using AppKeyPass_Ostanin.Models;
using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin.Pages
{
    public partial class Add : Page
    {
        Storage changeStorage;

        public Add(Storage storage = null)
        {
            InitializeComponent();
            changeStorage = storage;

            if (changeStorage != null)
            {
                tbName.Text = changeStorage.Name;
                tbUrl.Text = changeStorage.Url;
                tbLogin.Text = changeStorage.Login;
                tbPassword.Text = changeStorage.Password;
            }
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            if (changeStorage == null)
            {
                Storage newStorage = new Storage()
                {
                    Name = tbName.Text,
                    Url = tbUrl.Text,
                    Login = tbLogin.Text,
                    Password = tbPassword.Text
                };
                Storage result = await StorageContext.Add(newStorage);
                if (result == null) return;
            }
            else
            {
                changeStorage.Name = tbName.Text;
                changeStorage.Url = tbUrl.Text;
                changeStorage.Login = tbLogin.Text;
                changeStorage.Password = tbPassword.Text;
                Storage result = await StorageContext.Update(changeStorage);
                if (result == null) return;
            }
            MessageBox.Show("Данные записаны!");
            MainWindow.init.OpenPages(new Pages.Main());
        }

        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Main());
    }
}