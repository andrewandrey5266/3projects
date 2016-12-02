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
    class DBManager
    {
        string connectionString;
        public DBManager() :this(ConfigurationManager.ConnectionStrings["Library"].ConnectionString) {   }
        public DBManager(string connection)
        {
            connectionString = connection;
        }

        public List<Book> SelectAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from book;", sqlConnection);
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
        public void InsertBook(Book book)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(string.Format(
                    "insert into book(name, author, num_of_pages, _year) values ('{0}','{1}',{2}, {3});",
                    book.Name, book.Author, book.NumOfPages, book.Year), connection);

                var sqlReader = Convert.ToInt32((decimal)command.ExecuteNonQuery());
                MessageBox.Show(sqlReader + "book(s) was(were) added");

            }
        }

        public void RemoveBook(string nameOfBook)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = string.Format("delete from book where name = '{0}'", nameOfBook);
                connection.Open();
                var command = new SqlCommand(query, connection);

                var sqlReader = Convert.ToInt32((decimal)command.ExecuteNonQuery());                
                MessageBox.Show(sqlReader + " book(s) was(were) removed");

            }
        }

        public void UpdateBook(int oldBookId, Book newBook)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = string.Format("UPDATE book set name = '{0}', author = '{1}', num_of_pages = {2}, _year = {3} where book_id = {4}",
                    newBook.Name, newBook.Author, newBook.NumOfPages, newBook.Year, oldBookId);
                connection.Open();
                var command = new SqlCommand(query, connection);

                var sqlReader = Convert.ToInt32((decimal)command.ExecuteNonQuery());
                MessageBox.Show(sqlReader + " book(s) was(were) changed");

            }
        }

    }
}
