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
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace C_19_WPF
{
    /// <summary>
    /// Interaction logic for DeleteFromDbWindow.xaml
    /// </summary>
    public partial class DeleteFromDbWindow : Window
    {
        private readonly SqlCommand _sqlCommand = new SqlCommand();
        private readonly SqlConnection _sqlConnection = new SqlConnection
                (@"Data Source=РОМАН-ПК\SQLEXPRESS;Initial Catalog=C_19_DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private SqlDataReader _sqlDataReader;

        public DeleteFromDbWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Delete)
            {
                _sqlConnection.Open();
                _sqlCommand.Connection = _sqlConnection;
                _sqlCommand.CommandText = "delete from MyNewTable where Author='"+
                    AuthorIn.Text+"' and BName= '"+
                    UNameIn.Text+"' and Year='"+
                    YearIn.Text+"' and Pages='"+
                    PagesIn.Text+"'";
                _sqlCommand.ExecuteNonQuery();
                _sqlConnection.Close();
                Close();
            }
        }
    }
}
