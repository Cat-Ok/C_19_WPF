using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using C_19_WPF.SQL;

namespace C_19_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {

        #region variables
        public static MainWindow Mainwind = new MainWindow();
        public static bool Insert;
        public static bool Delete;
        public static bool Changee;
        private readonly SqlCommand _sqlCommand = new SqlCommand();
        private readonly SqlConnection _sqlConnection= new SqlConnection
                (@"Data Source=РОМАН-ПК\SQLEXPRESS;Initial Catalog=C_19_DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //private SqlDataReader _sqlDataReader;
        private InsertToDb _insertBut;
        private DeleteFromDbWindow _deleteFromDb;
        private Change _change;
        private Search _search;
        #endregion

        public MainWindow()
        {
            
            InitializeComponent();

           
        }

        public void MyDataConnection(string author,string name,int year, int pages)
        {
            if (Insert)
            {
                _sqlConnection.Open();
                _sqlCommand.Connection = _sqlConnection;
                _sqlCommand.CommandText = "insert into MyNewTable (Author,BName,Year,Pages) values ('" +
                                          author + "','" + name + "','" + year +
                                          "','" + pages + "')";
                _sqlCommand.ExecuteNonQuery();
                _sqlCommand.Clone();
                _sqlConnection.Close();
            }
        }

        private void ReadFromSqlDB_Click(object sender, RoutedEventArgs e)
        {
            using (C_19_DataBaseDataContext dbContext = new C_19_DataBaseDataContext())
            {
                var authorEntity = from author in dbContext.Tables select author.Author;
                var bookName = from name in dbContext.Tables select name.BName;
                var yearBook = from year in dbContext.Tables select year.Year;
                var pagesBook = from page in dbContext.Tables select page.Pages;

                SqlAuthorList.ItemsSource = authorEntity;
                SqlBNameList.ItemsSource = bookName;
                SqlYearList.ItemsSource = yearBook;
                SqlPageList.ItemsSource = pagesBook;
            }
        }

        private void ToDBButton_Click(object sender, RoutedEventArgs e)
        {
            Insert = true;
            _insertBut = new InsertToDb();
            _insertBut.Show();    
        }

        private void SqlBNameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Delete = true;
            _deleteFromDb = new DeleteFromDbWindow();
            _deleteFromDb.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Changee = true;
            _change = new Change();
            _change.Show();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _search = new Search();
            _search.Show();
        }      
    }
}
