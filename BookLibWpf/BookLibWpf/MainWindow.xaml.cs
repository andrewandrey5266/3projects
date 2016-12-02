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
        DBManager dbManager = new DBManager();
        int TempBookId;
        public MainWindow()
        {
            InitializeComponent();
        }        
        // pure sql
        private void SelectBook_Click(object sender, RoutedEventArgs e)
        {
            booksGrid.ItemsSource = dbManager.SelectAll();
        }       

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookBox.Visibility = Visibility.Visible;
            //null
            YesButton.Click -= YesButtonUpdateBook_Click;
            YesButton.Click -= YesButtonAdd_Click;
            //assign
            YesButton.Click += YesButtonAdd_Click;
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            FeatureText.Text = "Book's id";
            
            //null
            YesButton.Click -= YesButtonUpdateBook_Click;
            YesButton.Click -= YesButtonAdd_Click;
            //assign
            YesButton.Click += YesButtonUpdateBook_Click;


            Yes1Button.Click -= YesButtonRemove_Click;
            Yes1Button.Click -= YesButtonUpdateId_Click;

            Yes1Button.Click += YesButtonUpdateId_Click;
            
            OneFieldBox.Visibility = Visibility.Visible;
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            FeatureText.Text = "Book's name";

            Yes1Button.Click -= YesButtonRemove_Click;
            Yes1Button.Click -= YesButtonUpdateId_Click;
            Yes1Button.Click += YesButtonRemove_Click;

            OneFieldBox.Visibility = Visibility.Visible;
        }
        

        #region FIELD INPUT
        private void NoButtonField_Click(object sender, RoutedEventArgs e)
        {
            OneFieldBox.Visibility = Visibility.Collapsed;
        }
        private void YesButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            string bookName = FeatureTextBox.Text;
            dbManager.RemoveBook(bookName);

            NoButtonField_Click(null, null);
        }

        private void YesButtonUpdateId_Click(object sender, RoutedEventArgs e)
        {
            TempBookId = Convert.ToInt32(FeatureTextBox.Text);
            AddBookBox.Visibility = Visibility.Visible;

            NoButtonField_Click(null, null);
        }

        #endregion FIELD INPUT





        #region BOOK INPUT
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookBox.Visibility = Visibility.Collapsed;
        }
        private void YesButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            dbManager.InsertBook(AddBook_GetBook());

            NoButton_Click(null, null);
        }

        private void YesButtonUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            dbManager.UpdateBook(TempBookId, AddBook_GetBook());

            NoButton_Click(null, null);
        }

        private Book AddBook_GetBook()
        {
            return new Book
            {
                Name = NameTextBox.Text,
                Author = AuthorTextBox.Text,
                NumOfPages = Convert.ToInt32(NumOfPagesTextBox.Text),
                Year = Convert.ToInt32(YearTextBox.Text)
            };
        }
        #endregion BOOK INPUT
    }
}
