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
    /// Interaction logic for staffbut.xaml
    /// </summary>
    public partial class staffbut : Page
    {
        staffTableAdapter stafff = new staffTableAdapter();
        postTableAdapter post = new postTableAdapter();
        LoginDataTableAdapter login = new LoginDataTableAdapter();
        public staffbut()
        {
            InitializeComponent();
            farmdtg.ItemsSource = stafff.GetData();
            postcbx.ItemsSource = post.GetData();
            postcbx.DisplayMemberPath = "name";
            postcbx.SelectedValuePath = "post_id";
            rolecbx.ItemsSource = login.GetData();
            rolecbx.DisplayMemberPath = "login";
            rolecbx.SelectedValuePath = "LoginData_id";
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            stafff.InsertQuery(nametbx.Text, surnametbx.Text, lastnametbx.Text, Convert.ToInt32(rolecbx.SelectedValue), Convert.ToInt32(postcbx.SelectedValue));
            farmdtg.ItemsSource = stafff.GetData();
        }

        private void changebtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            stafff.UpdateQuery(nametbx.Text, surnametbx.Text, lastnametbx.Text, Convert.ToInt32(rolecbx.SelectedValue), Convert.ToInt32(postcbx.SelectedValue), (int)id);
            farmdtg.ItemsSource = stafff.GetData();
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (farmdtg.SelectedItem as DataRowView).Row[0];
            stafff.DeleteQuery(Convert.ToInt32(id));
            farmdtg.ItemsSource = stafff.GetData();
        }
    }
}
