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
using farmer.farmDataSetTableAdapters;

namespace farmer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginDataTableAdapter adapter = new LoginDataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var alllogins = adapter.GetData().Rows;
            for (int i = 0; i < alllogins.Count; i++) { 
                if (alllogins[i][1].ToString() == loginTbx.Text && alllogins[i][2].ToString() == PasswordTbx.Password) { 
                    int role_id = (int)alllogins[i][3];
                    switch (role_id)
                    {
                        case 4: 
                            for_staff role = new for_staff();
                            role.Show();
                            break;
                        case 2:
                            for_buyer second =  new for_buyer();
                            second.Show();
                            break;
                        case 9:
                            for_kassa third = new for_kassa();
                            third.Show();
                            break;
                    }
                }            
            }
        }
    }
}
