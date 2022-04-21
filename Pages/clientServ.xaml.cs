using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace Barhat.Pages
{
    /// <summary>
    /// Логика взаимодействия для clientServ.xaml
    /// </summary>
    public partial class clientServ : Page
    {
        DataTable dt_default = ExecuteSql($"SELECT [Name],[Image],[Weights],[Price]"
                    + " FROM [dbo].[catalog]");
        public clientServ()
        {
            InitializeComponent();//[eq

            DataTable dt = ExecuteSql($"SELECT [Name],[Image],[Weights],[Price]"
                    + " FROM [dbo].[catalog]");
            clientService.DataContext = this.Select("SELECT [Name],[Image],[Weights],[Price] FROM [dbo].[Catalog]");
            clientService.ItemsSource = this.Select("SELECT [Name],[Image],[Weights],[Price] FROM [dbo].[Catalog]").DefaultView;
            countLabel.Content = $"Записей выведено:{dt.Rows.Count} из {dt_default.Rows.Count}";

            List<string> sort = new List<string>() { "По возрастанию", "По убыванию" };
            sortBox.ItemsSource = sort;
        }

        static DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();

                using (read)
                {
                    dt.Load(read);
                }
            }
            return dt;
        }

        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            SqlConnection sqlConnection = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void sortChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sortBox.SelectedIndex == 0)
            {
                DataTable dt0 = ExecuteSql($"SELECT [Name],[Image],[Weights],[Price]"
                    + " FROM [dbo].[catalog] ORDER BY Price ASC");
                clientService.DataContext = dt0;
                clientService.ItemsSource = dt0.DefaultView;
                countLabel.Content = $"Записей выведено:{dt0.Rows.Count} из {dt_default.Rows.Count}";
            }
            if (sortBox.SelectedIndex == 1)
            {
                DataTable dt0 = ExecuteSql($"SELECT [Name],[Image],[Weights],[Price]"
                    + " FROM [dbo].[catalog] ORDER BY Price DESC");
                clientService.DataContext = dt0;
                clientService.ItemsSource = dt0.DefaultView;
                countLabel.Content = $"Записей выведено:{dt0.Rows.Count} из {dt_default.Rows.Count}";
            }
        }

        private void saleChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string search = searchBox.Text;
                DataTable dt1 = ExecuteSql($"SELECT [Name],[Image],[Weights],[Price]"
                    + $" FROM [dbo].[catalog] WHERE [Name] LIKE '%{search}%'");
                clientService.DataContext = dt1;
                clientService.ItemsSource = dt1.DefaultView;
                countLabel.Content = $"Записей выведено:{dt1.Rows.Count} из {dt_default.Rows.Count}";
            }
        }

        private void searchChanged(object sender, TextChangedEventArgs e)
        {
            string search = searchBox.Text;
            DataTable dt1 = ExecuteSql($"SELECT [Name],[Image],[Weights],[Price]"
                    + $" FROM [dbo].[catalog] WHERE [Name] LIKE '%{search}%'");
            clientService.DataContext = dt1;
            clientService.ItemsSource = dt1.DefaultView;
            countLabel.Content = $"Записей выведено:{dt1.Rows.Count} из {dt_default.Rows.Count}";
        }
    }
}
