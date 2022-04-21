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
    /// Логика взаимодействия для productSalePage.xaml
    /// </summary>
    public partial class productSalePage : Page
    {
        SqlConnection connect1 = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        string serv;

        public productSalePage()
        {
            InitializeComponent();

            string query = "select Id from [dbo].[catalog]";
            List<string> service = new List<string>();

            using (connect1)
            {
                connect1.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect1))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            service.Add(reader["Id"].ToString());
                        }
                    }
                }
            }
            serviceName.ItemsSource = service;
        }

        private void insertBut_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conne = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            if (serviceName.SelectedItem != null)
            {
                if (startTime.Text.Length > 0)
                {
                    using (conne)
                    {
                        conne.Open();
                        string query = "insert into [dbo].[order]([saledate], [productID], [clientId])"
                                     + "values(@date, @productId, @idClient)";
                        DataTable dt_client = this.Select($"SELECT [Id] FROM [dbo].[clients] WHERE [Phone] = '{phoneNumTb.Text}'");

                        using (SqlCommand cmd = new SqlCommand(query, conne))
                        {
                            cmd.Parameters.Add("@productId", SqlDbType.NVarChar).Value = serviceName.SelectedItem;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = startTime.Text;
                            cmd.Parameters.Add("@idClient", SqlDbType.Int).Value = (int)dt_client.Rows[0][0];
                            int rowsAdded = cmd.ExecuteNonQuery();
                            if (rowsAdded > 0)
                            {
                                MessageBox.Show("Заказ оформлен");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите дату и время доставки");
                }
            }
            else
            {
                MessageBox.Show("Введите название");
            }
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

        private void idSelect(object sender, SelectionChangedEventArgs e)
        {
            serv = serviceName.SelectedItem.ToString();
            DataTable dt_service = this.Select($"SELECT [Name] FROM [dbo].[catalog] WHERE id = '{serv}'");
            idServ.Text = dt_service.Rows[0][0].ToString();
        }
    }
}
