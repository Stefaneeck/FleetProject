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
        List<Driver> driverList;
        List<FuelCard> fuelCardList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddresses_Click(object sender, RoutedEventArgs e)
        {
            //proxy constructor with parameter endpoint name, because we have more than 1 endpoint defined (endpoint as configured in client app.config)
            ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");
            txtContent.Text = "";

            try
            {
                addressList = proxy.GetAddresses();

                foreach (Address item in addressList)
                {
                    txtContent.Text += item.Street + " " + item.Number + "\n" + item.Zipcode + " " + item.City;
                    txtContent.Text += "\n \n";
                }

            }
            catch(Exception ex)
            {
                txtContent.Text = ex.Message.ToString();
            }
            finally
            {
                proxy.Close();
            }
            
        }

        private void btnDrivers_Click(object sender, RoutedEventArgs e)
        {
            ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");
            txtContent.Text = "";

            try
            {
                driverList = proxy.GetDrivers();

                foreach (Driver item in driverList)
                {
                    txtContent.Text += "Name: " + item.Name + " " + item.FirstName + "\n" +
                        "Date of birth: " + item.DateOfBirth.ToShortDateString() + "\n" 
                        + "Soc sec nr: " + item.SocSecNumber + "\n"
                        + "active: " + item.Active;
                    txtContent.Text += "\n \n";
                }

            }
            catch (Exception ex)
            {
                txtContent.Text = ex.Message.ToString();
            }
            finally
            {
                proxy.Close();
            }

        }

        private void btnFuelCards_Click(object sender, RoutedEventArgs e)
        {
            ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");
            txtContent.Text = "";

            try
            {
                fuelCardList = proxy.GetFuelCards();

                foreach (FuelCard item in fuelCardList)
                {
                    txtContent.Text += "id: " + item.Id + "\n" + "Card nr: " + item.CardNumber   + "\n" +
                        "Pincode: " + item.Pincode + "\n"
                        + "Options: " + item.Options + "\n"
                        + "Valid until: " + item.ValidUntilDate.ToShortDateString();
                    txtContent.Text += "\n \n";
                }

            }
            catch (Exception ex)
            {
                txtContent.Text = ex.Message.ToString();
            }
            finally
            {
                proxy.Close();
            }
        }

        private void btnGetDriverById_Click(object sender, RoutedEventArgs e)
        {
            if(txtDriverId.Text != "Driver id" && txtDriverId.Text != string.Empty)
            {
                ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");
                txtContent.Text = "";
                int id = Int32.Parse(txtDriverId.Text);

                try
                {
                    var driver = proxy.GetDriverById(id);

                    txtContent.Text += "Name: " + driver.Name + " " + driver.FirstName + "\n" +
                        "Date of birth: " + driver.DateOfBirth.ToShortDateString() + "\n"
                        + "Soc sec nr: " + driver.SocSecNumber + "\n"
                        + "active: " + driver.Active;
                    txtContent.Text += "\n \n";
                }
                catch (Exception ex)
                {
                    txtContent.Text = ex.Message.ToString();
                }
                finally
                {
                    //https://stackoverflow.com/questions/2763592/the-communication-object-system-servicemodel-channels-servicechannel-cannot-be
                    if (proxy.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
                    proxy.Close();
                }
            }
            else
            {
                txtContent.Text = "Please enter driver id.";
            }
        }

        private void btnAddressById_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddressId.Text != "Address id" && txtAddressId.Text != string.Empty)
            {
                ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");
                txtContent.Text = "";
                int id = Int32.Parse(txtAddressId.Text);

                try
                {
                    var address = proxy.GetAddressById(id);

                    txtContent.Text += address.Street + " " + address.Number + "\n" + address.Zipcode + " " + address.City;
                    txtContent.Text += "\n \n";
                }
                catch (Exception ex)
                {
                    txtContent.Text = ex.Message.ToString();
                }
                finally
                {
                    //https://stackoverflow.com/questions/2763592/the-communication-object-system-servicemodel-channels-servicechannel-cannot-be
                    if (proxy.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
                        proxy.Close();
                }
            }
            else
            {
                txtContent.Text = "Please enter address id.";
            }
        }

        private void btnFuelcardById_Click(object sender, RoutedEventArgs e)
        {
            if (txtFuelCardId.Text != "Fuelcard id" && txtFuelCardId.Text != string.Empty)
            {
                ReadServiceClient proxy = new ReadServiceClient("NetTcpBinding_IReadService");
                txtContent.Text = "";
                int id = Int32.Parse(txtFuelCardId.Text);

                try
                {
                    var fuelCard = proxy.GetFuelCardById(id);

                    txtContent.Text += "id: " + fuelCard.Id + "\n" + "Card nr: " + fuelCard.CardNumber + "\n" +
                        "Pincode: " + fuelCard.Pincode + "\n"
                        + "Options: " + fuelCard.Options + "\n"
                        + "Valid until: " + fuelCard.ValidUntilDate.ToShortDateString();
                    txtContent.Text += "\n \n";
                }
                catch (Exception ex)
                {
                    txtContent.Text = ex.Message.ToString();
                }
                finally
                {
                    //https://stackoverflow.com/questions/2763592/the-communication-object-system-servicemodel-channels-servicechannel-cannot-be
                    if (proxy.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
                        proxy.Close();
                }
            }
            else
            {
                txtContent.Text = "Please enter fuelcard id.";
            }
        }
    }
}
