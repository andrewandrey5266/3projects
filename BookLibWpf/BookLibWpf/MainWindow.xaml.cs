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
using System.Configuration;
using System.Data.SqlClient;

namespace BookLibWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connection = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            booksGrid.ItemsSource = SelectAll();
         
            
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
        }

        private List<Book> SelectAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from book", sqlConnection);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                List<Book> result = new List<Book>();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        result.Add(new Book
                        {
                            Id = Convert.ToInt32(sqlReader["book_id"]),
                            Name = sqlReader["name"].ToString(),
                            Author = sqlReader["author"].ToString(),
                            NumOfPages = Convert.ToInt32(sqlReader["num_of_pages"]),
                            Year = Convert.ToInt32(sqlReader["_year"]),
                        });
                    }
                }

                return result;
            }

        }
        private void InsertBook(Book book)
        {
            using(var sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(string.Format("insert into book(name, author, num_of_pages, _year) values ('{0}','{1}',{2}, {3})",
                    book.Name, book.Author, book.NumOfPages, book.Year));

                var sqlReader = Convert.ToInt32((decimal)sqlCommand.ExecuteScalar());
                MessageBox.Show("You book was added with id " + sqlReader);
               
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
            InputBox.Children[""]
        }
    }
}
