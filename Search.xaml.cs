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
using C_19_WPF.SQL;
using System.Linq;
namespace C_19_WPF
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private readonly SqlCommand _sqlCommand = new SqlCommand();
        private readonly SqlConnection _sqlConnection = new SqlConnection
                (@"Data Source=РОМАН-ПК\SQLEXPRESS;Initial Catalog=C_19_DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Search()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQL.C_19_DataBaseDataContext dbContext = new SQL.C_19_DataBaseDataContext())
            {
                _sqlConnection.Open();

                _sqlCommand.Connection = _sqlConnection;
                 var auth = from aut in dbContext.Tables where aut.Author == AuthorIn.Text select aut.Author;
                 var book = from aut in dbContext.Tables where aut.Author == AuthorIn.Text select aut.BName;
                 var year = from aut in dbContext.Tables where aut.Author == AuthorIn.Text select aut.Year.ToString();
                 var page = from aut in dbContext.Tables where aut.Author == AuthorIn.Text select aut.Pages.ToString();
               
                ListA.ItemsSource = auth;
                ListB.ItemsSource = book;
                ListY.ItemsSource = year;
                ListP.ItemsSource = page;
                _sqlCommand.Clone();
                _sqlConnection.Close();
            }
        }
    }
}
