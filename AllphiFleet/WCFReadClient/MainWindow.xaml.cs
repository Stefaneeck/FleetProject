using System;
using System.Collections.Generic;
using System.Windows;
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
        //List<Driver> driverList;
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
                //driverList = proxy.GetDrivers();
                
                
                foreach(Address item in addressList)
                {
                    txtAddresses.Text += item.Street + item.Number + ", " + item.Zipcode + item.City;
                    txtAddresses.Text += "\n";
                }

            }
            catch(Exception ex)
            {
                txtAddresses.Text = ex.Message.ToString();
            }
            finally
            {
                proxy.Close();
            }
            
        }
    }
}
