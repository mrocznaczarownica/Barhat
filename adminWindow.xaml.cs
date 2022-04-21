using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Barhat.Pages;

namespace Barhat
{
    /// <summary>
    /// Логика взаимодействия для adminWindow.xaml
    /// </summary>
    public partial class adminWindow : Window
    {
        public adminWindow()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            addPage1 add = new addPage1();
            mainFr.NavigationService.Navigate(add);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            addPage edit = new addPage();
            mainFr.NavigationService.Navigate(edit);
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            deletePage delete = new deletePage();
            mainFr.NavigationService.Navigate(delete);
        }

        private void ordrsClick(object sender, RoutedEventArgs e)
        {
            ordersPageAdmin orders = new ordersPageAdmin();
            mainFr.NavigationService.Navigate(orders);
        }
    }
}
