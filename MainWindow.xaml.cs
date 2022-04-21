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

using Barhat.Pages;

namespace Barhat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string testlog;

        public MainWindow()
        {
            InitializeComponent();

            clientServ client = new clientServ();
            mainFr.NavigationService.Navigate(client);
        }

        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            productSalePage productSale = new productSalePage();
            mainFr.NavigationService.Navigate(productSale);
        }
    }
}
