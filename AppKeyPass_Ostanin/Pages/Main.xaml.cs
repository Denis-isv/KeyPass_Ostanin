using AppKeyPass_Ostanin.Contexts;
using AppKeyPass_Ostanin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin.Pages
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            Loaded += async (sender, e) => await GetStorage();
        }

        public async Task GetStorage()
        {
            List<Storage> storages = await StorageContext.Get();
            StorageList.Children.Clear();

            if (storages != null)
            {
                foreach (Storage storage in storages)
                    StorageList.Children.Add(new Elements.Item(storage, this));
            }
        }

        private void OpenPagesAdd(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Add());
    }
}