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
using KoriIllapaDAO.Model;
using KoriIllapaDAO.Implementation;
using System.Text.RegularExpressions;
using System.Data;

namespace KoriIllapaWPF.Transport
{
    /// <summary>
    /// Lógica de interacción para searchTransport.xaml
    /// </summary>
    public partial class searchTransport : Window
    {
        Features features;
        FeaturesImpl implFeatures;
        Transports transports;
        TransportImpl implTransport;
        public searchTransport()
        {
            InitializeComponent();
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void dgTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTransport.SelectedItem != null && dgTransport.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgTransport.SelectedItem;
                    short id = short.Parse(d.Row.ItemArray[0].ToString());
                    implFeatures = new FeaturesImpl();
                    features = implFeatures.Get(id);

                    if (features != null)
                    {
                        txbLicensePlate.Text = features.licensePlate;
                        txbCapacityLoad.Text = features.capacityLoad + " t";
                        txbColor.Text = features.color;
                        txbBrand.Text = features.brand;
                        txbType.Text = features.reference.ToString();

                        string pathCharge = Config.pathPhotoTransports + id + ".jpg";
                        imgTransport.Source = new BitmapImage(new Uri(pathCharge));

                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(txtSearch.Text.Trim().Length > 2)
                {
                    if (Regex.IsMatch(txtSearch.Text, @"[%]"))
                    {
                        dgTransport.ItemsSource = null;
                    }
                    else
                    {
                        implFeatures = new FeaturesImpl();
                        dgTransport.ItemsSource = null;
                        dgTransport.ItemsSource = implFeatures.Search(txtSearch.Text).DefaultView;
                        dgTransport.Columns[0].Visibility = Visibility.Collapsed;
                    }
                }
                lblResult.Content = dgTransport.Items.Count + " registros encontrados";
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en el proceso comuniquese con el Area de Sistemas", "Kori-Illapa");
                throw error;
            }
        }

        private void miModificar_Click(object sender, RoutedEventArgs e)
        {
            CargarUserControl();
        }

        private void miEliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarTransport();
        }

        private void miAgregar_Click(object sender, RoutedEventArgs e)
        {
            UserControl trans = null;
            gridSearch.Children.Clear();
            trans = new Transport.uscTransportAdd();

            gridSearch.Children.Add(trans);
        }
        void CargarUserControl()
        {
            if(features != null)
            {
                imgTransport.Source = null;
                this.Visibility = Visibility.Collapsed;
                wpfTransportMode mode = new wpfTransportMode(features);
                mode.ShowDialog();
                this.Visibility = Visibility.Visible;
                limpiar();
            }
            else
            {
                lblResult.Content = "Debe seleccionar un registro";
            }
        }
        void eliminarTransport()
        {
            transports = new Transports(features.Id, features.licensePlate, features.transportType);
            if (transports != null)
            {
                if (MessageBox.Show("¿Esta segur@ \n de eliminar el registro?", "KORI_ILLAPA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implTransport = new TransportImpl();
                        int n = implTransport.Delete(transports);
                        if (n > 0)
                        {
                            lblResult.Content = "Se elimino correctamente";
                        }
                        else
                        {
                            lblResult.Content = "Sucedio un error";
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                        throw error;
                    }
                }
                limpiar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar");
            }
        }
        void limpiar()
        {
            dgTransport.ItemsSource = null;
            imgTransport.Source = null;
            txbBrand.Text = "Ninguno";
            txbCapacityLoad.Text = "Ninguno";
            txbColor.Text = "Ninguno";
            txbLicensePlate.Text = "Ninguno";
            txbType.Text = "Ninguno";
            txtSearch.Text = "";
        }
    }
}
