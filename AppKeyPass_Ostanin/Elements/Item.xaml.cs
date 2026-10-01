using AppKeyPass_Ostanin.Contexts;
using AppKeyPass_Ostanin.Pages;
using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Storage Storage;
        Main Main;

        public Item(Storage storage, Main main)
        {
            InitializeComponent();
            tbName.Text = storage.Name;
            tbUrl.Text = storage.Url;
            tbLogin.Text = storage.Login;
            tbPassword.Text = storage.Password;
            this.Main = main;
            this.Storage = storage;
        }
        private void Update(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Add(Storage));
        }
        private void Delete(object sender, System.Windows.RoutedEventArgs e)
        {
            StorageContext.Delete(Storage.Id);
            this.Main.StorageList.Children.Remove(this);
            MessageBox.Show("Данные удалены");
        }
    }
}
