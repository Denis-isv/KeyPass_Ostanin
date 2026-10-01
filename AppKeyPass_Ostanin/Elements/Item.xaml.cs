using AppKeyPass_Ostanin.Contexts;
using AppKeyPass_Ostanin.Models;
using AppKeyPass_Ostanin.Pages;
using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin.Elements
{
    public partial class Item : UserControl
    {
        Storage currentStorage;
        Main mainPage;

        public Item(Storage storage, Main main)
        {
            InitializeComponent();
            tbName.Text = storage.Name;
            tbUrl.Text = storage.Url;
            tbLogin.Text = storage.Login;
            tbPassword.Text = storage.Password;
            this.mainPage = main;
            this.currentStorage = storage;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Add(currentStorage));
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            await StorageContext.Delete(currentStorage.Id);
            mainPage.StorageList.Children.Remove(this);
            MessageBox.Show("Данные удалены");
        }
    }
}