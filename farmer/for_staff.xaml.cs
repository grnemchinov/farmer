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
using farmer.farmDataSetTableAdapters;

namespace farmer
{
    /// <summary>
    /// Interaction logic for for_staff.xaml
    /// </summary>
    public partial class for_staff : Window
    {

        public for_staff()
        {
            InitializeComponent();
            PageFrame.Content = new rolebut();
        }

        private void staffbtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new staffbut();
        }

        private void rolebtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new rolebut();
        }

        private void autorisebtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new autorisebut();
        }
    }
}
