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
using System.Windows.Shapes;

namespace Barhat
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string log;

        public Login()
        {
            InitializeComponent();
        }

        private void loginButtonClick(object sender, RoutedEventArgs e)
        {
            if (logintb.Text.Length > 0)
            {
                if (passtb.Password.Length > 0)
                {
                    DataTable dtClient = this.Select($"SELECT * FROM [dbo].[clients] WHERE [login] = {logintb.Text} AND " +
                        $"[password] = {passtb.Password}");
                    DataTable dtAdmin = this.Select($"SELECT * FROM [dbo].[admins] WHERE [login] = {logintb.Text} AND " +
                        $"[password] = {passtb.Password}");                   

                    if (dtClient.Rows.Count > 0)
                    {
                        log = logintb.Text;
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Hide();
                    }
                    else if(dtAdmin.Rows.Count > 0)
                    {
                        log = logintb.Text;
                        adminWindow admin = new adminWindow();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка введенных данных");
                    }
                }
                else
                {
                    nofiticationPass.Content = "Данное поле осталось пустым";
                }
            }
            else
            {
                nofiticationLog.Content = "Данное поле осталось пустым";
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
    }
}
