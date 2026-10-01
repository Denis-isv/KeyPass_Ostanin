using AppKeyPass_Ostanin.Contexts;
using AppKeyPass_Ostanin.Models;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            GetStorage();
        }

        public async Task GetStorage()
        {
            List<Storage> Storages = await StorageContext.Get();
            StorageList.Children.Clear();
            foreach (Storage Storage in Storages)
                StorageList.Children.Add(new Elements.Item(Storage, this));
        }

        private void OpenPagesAdd(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Add());
    }
}
