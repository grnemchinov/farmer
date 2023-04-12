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
using System.Windows.Shapes;
using farmer.farmDataSetTableAdapters;

namespace farmer
{
    /// <summary>
    /// Interaction logic for for_buyer.xaml
    /// </summary>
    public partial class for_buyer : Window
    {
        productTableAdapter product = new productTableAdapter();
        costTableAdapter cost = new costTableAdapter();
        public for_buyer()
        {
            InitializeComponent();
            farmdtg.ItemsSource = product.GetData();
            costcbx.ItemsSource = cost.GetData();
            costcbx.DisplayMemberPath = "sale";
            costcbx.SelectedValuePath = "cost_id";
        }

        private void addbtn_Click_1(object sender, RoutedEventArgs e)
        {
            product.InsertQuery(Convert.ToInt32(quontitytbx.Text), freshnesstbx.Text, Convert.ToInt32(costcbx.SelectedValue), nametbx.Text);
            farmdtg.ItemsSource = product.GetData();
        }

        private void changebtn_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            product.UpdateQuery(Convert.ToInt32(quontitytbx.Text), freshnesstbx.Text, Convert.ToInt32(costcbx.SelectedValue), nametbx.Text, (int)id);
            farmdtg.ItemsSource = product.GetData();
        }

        private void delbtn_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            product.DeleteQuery(Convert.ToInt32(id));
            farmdtg.ItemsSource = product.GetData();
        }

        private void importbtn_Click(object sender, RoutedEventArgs e)
        {
            List<jsomcreator> forImport1 = farmconverter.DeserializeObject<List<jsomcreator>>();

            if (forImport1 != null)
            {
                foreach (var item in forImport1)
                {
                    product.InsertQuery(Convert.ToInt32(item.quontity), item.freshness, Convert.ToInt32(item.cost_id), item.name);

                }
                farmdtg.ItemsSource = product.GetData();
            }
        }
    }
}
