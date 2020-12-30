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
using WCFReadClient.WCFReadServices;
using WCFReadEntities;

namespace WCFReadClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Address> addressList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddresses_Click(object sender, RoutedEventArgs e)
        {
            //proxy constructor with parameter endpoint name, because we have more than 1 endpoint defined (endpoint as configured in client app.config)
            ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");

            try
            {
                addressList = proxy.GetAddresses();
                txtAddresses.Text = addressList.ToString();
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                proxy.Close();
            }
            
        }
    }
}
