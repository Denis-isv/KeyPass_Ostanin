using System.Windows;
using System.Windows.Controls;

namespace AppKeyPass_Ostanin
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public static string Token;

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(new Pages.Login());
        }

        public void OpenPages(Page OpenPage)
        {
            frame.Navigate(OpenPage);
        }
    }
}