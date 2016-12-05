using System;
using System.Windows;
using BookLibWpf.Views;
using BookLibWpf.Models;
using BookLibWpf.Presenters;

namespace BookLibWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IService<Book> model = new EFService(new LibraryContext());

        public MainWindow()
        {
            InitializeComponent();            
        }
        // pure sql
        private void SelectBook_Click(object sender, RoutedEventArgs e)
        {
            booksGrid.ItemsSource = model.Select();
        }       

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            SubWindow1 view = new SubWindow1();            
            ActorPresenter presenter = new ActorPresenter(model, view);
            view.Show();
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            SubWindow2 view = new SubWindow2();
            FieldPresenter presenter = new FieldPresenter(model, view);
            view.Show();
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book selectedBook = (Book)booksGrid.SelectedItem;
                model.Delete(selectedBook);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        
   





   
    }
}
