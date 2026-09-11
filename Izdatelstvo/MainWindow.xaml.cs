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
using System.Data.SqlClient;

namespace Izdatelstvo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            string ConnectString = "Integrated Security=false;User Id=" + log.Text +
                ";Password=" + pas.Text + ";Initial Catalog=" +
                bd.Text + ";server=" + serv.Text;
            SqlConnection con = new SqlConnection(ConnectString);
            Exception error = null;
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                error = ex;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (error == null)
                {
                    newForm newForm = new newForm(ConnectString); newForm.Show();
                }
                con.Close();
            }
        }
    }
}
