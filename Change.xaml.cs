using System;
using System.Data.SqlClient;
using System.Windows;
using C_19_WPF.SQL;
using System.Linq;

namespace C_19_WPF
{
    /// <summary>
    /// Interaction logic for Change.xaml
    /// </summary>
    public partial class Change:Window
    {
        private readonly SqlCommand _sqlCommand = new SqlCommand();
        private readonly SqlConnection _sqlConnection = new SqlConnection
                (@"Data Source=РОМАН-ПК\SQLEXPRESS;Initial Catalog=C_19_DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Change()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sqlConnection.Open();
            _sqlCommand.Connection = _sqlConnection;
            _sqlCommand.CommandText = "update MyNewTable set Author='" + 
                AuthorOut.Text + "' ,BName='" + 
                UNameOut.Text + "' ,Year='" + 
                YearOut.Text + "' ,Pages='" + 
                PagesOut.Text + "' where Author='" + 
                AuthorIn.Text + "' and BName='" + 
                UNameIn.Text + "' and Year='" + 
                YearIn  .Text + "' and Pages='" + 
                PagesIn.Text + "'";
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            Close();
        }
    }
}
