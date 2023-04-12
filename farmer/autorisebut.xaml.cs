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
    /// Interaction logic for autorisebut.xaml
    /// </summary>
    public partial class autorisebut : Page
    {
        LoginDataTableAdapter login = new LoginDataTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        public autorisebut()
        {
            InitializeComponent();
            farmdtg.ItemsSource = login.GetData();
            usertbx.ItemsSource = role.GetData();
            usertbx.DisplayMemberPath = "name";
            usertbx.SelectedValuePath = "role_id";
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            login.InsertQuery(logintbx.Text, passwordtbx.Text, Convert.ToInt32(usertbx.SelectedValue));
            farmdtg.ItemsSource = login.GetData();
        }

        private void changebtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            login.UpdateQuery(logintbx.Text, passwordtbx.Text, Convert.ToInt32(usertbx.SelectedValue), (int)id);
            farmdtg.ItemsSource = login.GetData();
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            login.DeleteQuery(Convert.ToInt32(id));
            farmdtg.ItemsSource = login.GetData();
        }
    }
}
