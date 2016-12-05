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

namespace BookLibWpf.Views
{
    /// <summary>
    /// Interaction logic for SubWindow2.xaml
    /// </summary>
    public partial class SubWindow2 : Window, IView<int>
    {
        public event EventHandler<int> ProcessInput;

        public SubWindow2()
        {
            InitializeComponent();
        }
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            int bookId = int.Parse(FeatureTextBox.Text);
            ProcessInput(this, bookId);

            NoButton_Click(null, null);
        }


       
    }
}
