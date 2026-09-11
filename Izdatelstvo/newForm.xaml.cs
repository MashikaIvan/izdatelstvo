using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace Izdatelstvo
{
    /// <summary>
    /// Логика взаимодействия для newForm.xaml
    /// </summary>
    public partial class newForm : Window
    {
        public newForm(string ConnectString)
        {
            InitializeComponent();
            this.ConnectString = ConnectString;
        }

        public string ConnectString;

        private void zapros_Click(object sender, RoutedEventArgs e)
        {
            String quertString = @"select count(Id_kategorii) from Kategorii;";
            SqlConnection con = new SqlConnection(ConnectString);
            SqlCommand count = new SqlCommand(quertString, con);
            con.Open();
            SqlDataReader reader = count.ExecuteReader();
            reader.Read();
            result.Text = reader[0].ToString();
            con.Close();
        }

        private void zapros2_Click(object sender, RoutedEventArgs e)
        {
            string queryString = @"select * from Kategorii;";
            SqlConnection con = new SqlConnection(ConnectString);
            SqlCommand table = new SqlCommand(queryString, con);
            con.Open();
            SqlDataReader reader = table.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dg.ItemsSource = dt.DefaultView;
            reader.Close();
            con.Close();
        }

        private void addnew_Click(object sender, RoutedEventArgs e)
        {
            String quertString = @"insert into Kategorii (Name_kategorii) values('" + newkat.Text + "');";

            SqlConnection con = new SqlConnection(ConnectString);
            SqlCommand insert = new SqlCommand(quertString, con);
            con.Open();
            insert.ExecuteNonQuery();
            con.Close();
        }
    }
}
