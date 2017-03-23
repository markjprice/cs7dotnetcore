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

namespace Ch12_GUITasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(
              @"Data Source=(localdb)\mssqllocaldb;" +
              "Initial Catalog=Northwind;Integrated Security=true;");

            await connection.OpenAsync();

            var getProducts = new SqlCommand(
              "WAITFOR DELAY '00:00:05';" +
              "SELECT ProductID, ProductName, UnitPrice FROM Products",
              connection);

            SqlDataReader reader = await getProducts.ExecuteReaderAsync();

            int indexOfID = reader.GetOrdinal("ProductID");
            int indexOfName = reader.GetOrdinal("ProductName");
            int indexOfPrice = reader.GetOrdinal("UnitPrice");

            while (await reader.ReadAsync())
            {
                ProductsListBox.Items.Add(
                    string.Format("{0}: {1} costs {2:c}",
                    await reader.GetFieldValueAsync<int>(indexOfID),
                    await reader.GetFieldValueAsync<string>(indexOfName),
                    await reader.GetFieldValueAsync<decimal>(indexOfPrice)));
            }
            reader.Dispose();
            connection.Dispose();
        }
    }
}
