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
using System.Linq;
using System.Windows;
using C_19_WPF.SQL;

namespace C_19_WPF
{
    /// <summary>
    /// Interaction logic for InsertToDb.xaml
    /// </summary>
    public partial class InsertToDb : Window
    {
        private readonly SqlCommand _sqlCommand = new SqlCommand();
        private readonly SqlConnection _sqlConnection = new SqlConnection
                (@"Data Source=РОМАН-ПК\SQLEXPRESS;Initial Catalog=C_19_DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private SqlDataReader _sqlDataReader;
        public InsertToDb()
        {
            InitializeComponent();
        }

        private void AuthorDB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UNameDB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void YearDB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public string GetAuthor
        {
            get
            {
                return AuthorDB.
                        Text;
            }
            set { AuthorDB.Text = value; }
        }

        public string GetUName
        {
            get
            {
                return UNameDB.
                        Text;
            }
            set { UNameDB.Text = value; }
        }

        public int GetYear
        {
            get
            {
                if (YearDB.Text != "")
                {
                    return Convert.ToInt32(YearDB.Text);
                }
                return 0;
            }
            set { YearDB.Text = value.ToString(); }
        }

        public int GetPages
        {
            get
            {
                if (PagesDB.Text != "")
                    return Convert.ToInt32(PagesDB.Text);
                return 0;
            }
            set { PagesDB.Text = value.ToString(); }
        }

        private void InsertToDB_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorDB.Text != ""
                && UNameDB.Text != ""
                && YearDB.Text != null
                && PagesDB.Text != null)
            {
                MyDataConnection();
                Close();
            }
        }

        public void MyDataConnection()
        {
            if (MainWindow.Insert)
            {
                _sqlConnection.Open();
                _sqlCommand.Connection = _sqlConnection;
                _sqlCommand.CommandText = "insert into MyNewTable (Author,BName,Year,Pages) values ('" +
                                          AuthorDB.Text + "','" + UNameDB.Text + "','" + YearDB.Text +
                                          "','" + PagesDB.Text + "')";
                _sqlCommand.ExecuteNonQuery();
                _sqlCommand.Clone();
                _sqlConnection.Close();
            }
        }
    }
}
