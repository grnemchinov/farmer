using System;
using System.Collections.Generic;
using System.Data;
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
using farmer.farmDataSetTableAdapters;

namespace farmer
{
    /// <summary>
    /// Interaction logic for rolebut.xaml
    /// </summary>
    public partial class rolebut : Page
    {
        roleTableAdapter role = new roleTableAdapter();
        public rolebut()
        {
            InitializeComponent();
            farmdtg.ItemsSource = role.GetData();
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            role.InsertQuery(nametbx.Text);
            farmdtg.ItemsSource = role.GetData();
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            role.DeleteQuery(Convert.ToInt32(id));
            farmdtg.ItemsSource = role.GetData();
        }

        private void changebtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            role.UpdateQuery(nametbx.Text, (int)id);
            farmdtg.ItemsSource = role.GetData();
        }
    }
}
