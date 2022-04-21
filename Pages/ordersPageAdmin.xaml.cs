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

namespace Barhat.Pages
{
    /// <summary>
    /// Логика взаимодействия для ordersPageAdmin.xaml
    /// </summary>
    public partial class ordersPageAdmin : Page
    {
        public ordersPageAdmin()
        {
            InitializeComponent();

            ordersGrid.DataContext = this.Select($"SELECT * FROM [dbo].[Catalog]");
            ordersGrid.ItemsSource = this.Select($"SELECT * FROM [dbo].[Catalog]").DefaultView;
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
    }
}
