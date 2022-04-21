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
    /// Логика взаимодействия для addPage1.xaml
    /// </summary>
    public partial class addPage1 : Page
    {
        SqlConnection conn = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string query;

        public addPage1()
        {
            InitializeComponent();
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
            int val;
            if (!Int32.TryParse(e.Text, out val))
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

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string query = "insert into [dbo].[catalog]([Name], [Price], [Weights], "
                + " [Description], [Image]) values(@name, @price, @weights, @desc, @image)";
            if (name.Text.Length > 0)
            {
                if (count.Text.Length > 0)
                {
                    if (weight.Text.Length > 0)
                    {
                        if (pic.Text.Length > 0)
                        {
                            using (conn)
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name.Text;
                                    cmd.Parameters.Add("@price", SqlDbType.NVarChar).Value = count.Text;
                                    cmd.Parameters.Add("@weights", SqlDbType.NVarChar).Value = weight.Text;
                                    cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = desc.Text;
                                    cmd.Parameters.Add("@image", SqlDbType.NVarChar).Value = pic.Text;
                                    int rowsAdded = cmd.ExecuteNonQuery();
                                    if (rowsAdded > 0)
                                    {
                                        MessageBox.Show("Данные зарегистрированы");
                                        this.Visibility = Visibility.Hidden;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Осталось пустое поле: Изображение");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Осталось пустое поле: Масса");
                    }
                }
                else
                {
                    MessageBox.Show("Осталось пустое поле: Стоимость");
                }
            }
            else
            {
                MessageBox.Show("Осталось пустое поле: Название");
            }
        }

        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            SqlConnection sqlConnection = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //SqlConnection sqlConnection = new SqlConnection("Data Source=192.168.227.12;Initial Catalog=prakticaHamud_and_Tilik;User ID=user05;Password=05;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
