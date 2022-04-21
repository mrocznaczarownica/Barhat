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
    /// Логика взаимодействия для deletePage.xaml
    /// </summary>
    public partial class deletePage : Page
    {
        SqlConnection conn = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlConnection connect1 = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string query;
        public deletePage()
        {
            InitializeComponent();
            string query = "select [Id] from [dbo].[catalog]";
            List<string> ID = new List<string>();
            using (connect1)
            {
                connect1.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect1))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID.Add(reader["Id"].ToString());
                        }
                    }
                }
            }
            idBox.ItemsSource = ID;
        }

        private void id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = int.Parse((string)idBox.SelectedItem);
            DataTable dt_Name = this.Select($"select [Name] from [dbo].[catalog] where [Id] ='{id}'");
            DataTable dt_count = this.Select($"select [Price] from [dbo].[catalog] where [Id] ='{id}'");
            DataTable dt_time = this.Select($"select [Weights] from [dbo].[catalog] where [Id] ='{id}'");
            DataTable dt_sale = this.Select($"select [Description] from [dbo].[catalog] where [Id] ='{id}'");
            DataTable dt_image = this.Select($"select [Image] from [dbo].[catalog] where [Id] ='{id}'");

            name.Text = dt_Name.Rows[0][0].ToString();
            count.Text = dt_count.Rows[0][0].ToString() + " руб.";
            weights.Text = dt_time.Rows[0][0].ToString();
            desc.Text = dt_sale.Rows[0][0].ToString();
            pic.Text = dt_image.Rows[0][0].ToString();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void time_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Int32.TryParse(e.Text, out int val))
            {
                e.Handled = true;
            }
        }

        private void time_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
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

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse((string)idBox.SelectedItem);

            string query = $"delete from [dbo].[catalog] where [id] ='{id}'";
            using (conn)
            {
                conn.Open();
                using SqlCommand cmd = new SqlCommand(query, conn);
                int rowsAdded = cmd.ExecuteNonQuery();
                if (rowsAdded > 0)
                {
                    MessageBox.Show("Данные удалены");
                }
            }
        }
    }
}
