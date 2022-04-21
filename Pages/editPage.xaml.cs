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
    /// Логика взаимодействия для addPage.xaml
    /// </summary>
    public partial class addPage : Page
    {
        SqlConnection conn = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlConnection conne = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlConnection connect1 = new SqlConnection("Data Source=shepard.keenetic.link;Initial Catalog=diplom;User ID=sa;Password=Alternativa0;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string query;

        public addPage()
        {
            InitializeComponent();

            string query = "select Id from catalog";
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
            int id = int.Parse(idBox.SelectedItem.ToString());
            string query = "update [dbo].[catalog] set [Name] = @name, [Image] = @pic, " +
                "[Weights] = @weight, [Price] = @count, [Description] = @desc where [Id] = '" + id + "'";
            if (name.Text.Length > 0)
            {
                if (pic.Text.Length > 0)
                {
                    using (conn)
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name.Text;
                            cmd.Parameters.Add("@count", SqlDbType.NVarChar).Value = count.Text;
                            cmd.Parameters.Add("@weight", SqlDbType.Float).Value = weight.Text;
                            cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = desc.Text;
                            cmd.Parameters.Add("@pic", SqlDbType.NVarChar).Value = pic.Text;
                            int rowsAdded = cmd.ExecuteNonQuery();
                            if (rowsAdded > 0)
                            {
                                MessageBox.Show("Данные обновлены");
                                this.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Добавьте картинку");
                }
            }
            else
            {
                MessageBox.Show("Название не может быть пустым");
            }
        }

        private void id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (conne)
            {
                int id = int.Parse(idBox.SelectedItem.ToString());
                string sqlcmd = "select * from [dbo].[catalog] where [Id] ='" + id + "'";
                conne.Open();
                SqlCommand cmd = new SqlCommand(sqlcmd, conne);
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    name.Text = rd[1].ToString();
                    count.Text = rd[2].ToString();
                    weight.Text = rd[3].ToString();
                    desc.Text = rd[4].ToString();
                    pic.Text = rd[5].ToString();
                }
            }
        }
    }
}
