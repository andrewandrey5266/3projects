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
using BookLibWpf.Models;

namespace BookLibWpf.Views
{
    /// <summary>
    /// Interaction logic for SubWindow1.xaml
    /// </summary>
    public partial class SubWindow1 : Window, IView<ProjectEventArgs>
    {
        public event EventHandler<ProjectEventArgs> ProcessInput = delegate { };
        
        public SubWindow1()
        {
            InitializeComponent();
        }        
        
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput(this, new ProjectEventArgs(GetBook()));
            NoButton_Click(null, null);            
        }

        private Book GetBook()
        {
            return new Book
            {
                Name = NameTextBox.Text,
                Author = AuthorTextBox.Text,
                NumOfPages = Convert.ToInt32(NumOfPagesTextBox.Text),
                Year = Convert.ToInt32(YearTextBox.Text)
            };
        }




        
    }
}
