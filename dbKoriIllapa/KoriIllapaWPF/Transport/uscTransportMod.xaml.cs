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
using KoriIllapaDAO.Model;
using KoriIllapaDAO.Implementation;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace KoriIllapaWPF.Transport
{
    /// <summary>
    /// Lógica de interacción para uscTransportMod.xaml
    /// </summary>
    public partial class uscTransportMod : UserControl
    {
        byte flag = 0;
        private string PathTemp = @"C:\KoriIllapa\Images\Temp\temp.jpg";
        byte dg = 0;
        string path = "";
        string pathAux = "";
        FeaturesImpl implFeature;
        Features features;
        TransportImpl implTransport;
        Transports transports;
        byte transportType;
        public uscTransportMod()
        {
            InitializeComponent();
        }
        public uscTransportMod(Features f)
        {
            InitializeComponent();
            this.features = f;
            btnDelete.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            FillComboTransport();
            LoadTransport();
        }

        private void btnImageTransport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivos de Imagen|*.jpg";
            if (file.ShowDialog() == true)
            {
                path = file.FileName;
                imgTransport.Source = new BitmapImage(new Uri(path));
            }
            flag = 1;
        }

        private void dgTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dg = 1;
            if (dgTransport.SelectedItem != null && dgTransport.Items.Count > 0)
            {
                try
                {
                    transportType = byte.Parse(cbxTransporType.SelectedValue.ToString());
                    DataRowView d = (DataRowView)dgTransport.SelectedItem;
                    short id = short.Parse(d.Row.ItemArray[0].ToString());
                    implFeature = new FeaturesImpl();
                    features = implFeature.Get(id);

                    if (features != null)
                    {
                        txtLicense.Text = features.licensePlate;
                        cbxTransporType.SelectedIndex = features.transportType - 4;
                        txtBrand.Text = features.brand;
                        txtColor.Text = features.color;
                        txtCapacity.Text = features.capacityLoad.ToString();
                        
                        string pathCharge = Config.pathPhotoTransports + features.Id + ".jpg";
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            #region Validaciones
            transports = new Transports(features.Id, features.licensePlate, features.transportType);

            if(dg == 1)
            {
                transports = new Transports();
                DataRowView d = (DataRowView)dgTransport.SelectedItem;
                byte id = byte.Parse(d.Row.ItemArray[0].ToString());
                transports.id = id;
                features.Id = id;
                features = implFeature.Get(features.Id);
                transports = new Transports(features.Id, features.licensePlate, features.transportType);
            }

            transportType = byte.Parse(cbxTransporType.SelectedValue.ToString());
            transports.licensePlate = txtLicense.Text;
            transports.transportType = transportType;

            features.brand = txtBrand.Text;
            features.color = txtColor.Text;
            features.capacityLoad = short.Parse(txtCapacity.Text);
           

            implFeature = new FeaturesImpl();
            implFeature.Update(transports, features);

            if(flag == 1)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

                File.Delete(Config.pathPhotoTransports + features.Id + ".jpg");
                File.Copy(path, Config.pathPhotoTransports + features.Id + ".jpg");
            }
              
            lblResult.Content = "Se actualizo correctamente";
            Select();
            limpiar();
            #endregion
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            transports = new Transports();
            DataRowView d = (DataRowView)dgTransport.SelectedItem;
            byte id = byte.Parse(d.Row.ItemArray[0].ToString());

            transports.id = id;
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
                            Select();
                            limpiar();
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
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar");
            }
        }
        void FillComboTransport()
        {
            implTransport = new TransportImpl();
            try
            {
                cbxTransporType.ItemsSource = null;
                cbxTransporType.DisplayMemberPath = "transportTypeName";
                cbxTransporType.SelectedValuePath = "id";
                cbxTransporType.ItemsSource = implTransport.SelectComboTransportType().DefaultView;
                cbxTransporType.SelectedIndex = 0;
            }
            catch (Exception error)
            {

                throw error;
            }
        }
        private void Select()
        {
            implTransport = new TransportImpl();
            dgTransport.ItemsSource = null;
            try
            {
                dgTransport.ItemsSource = implTransport.Select().DefaultView;
                dgTransport.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                throw error;
            }
        }
        void limpiar()
        {
            txtLicense.Text = "";
            txtBrand.Text = "";
            txtCapacity.Text = "";
            txtColor.Text = "";
            imgTransport.Source = null;
        }
        void LoadTransport()
        {
            if (features != null)
            {
                txtLicense.Text = features.licensePlate;
                cbxTransporType.SelectedIndex = features.transportType - 4;
                txtBrand.Text = features.brand;
                txtColor.Text = features.color;
                txtCapacity.Text = features.capacityLoad.ToString();

                path = Config.pathPhotoTransports + features.Id + ".jpg";
                imgTransport.Source = new BitmapImage(new Uri(path));

                pathAux = path;
            }
        }

        private void btnCameraTransport_Click(object sender, RoutedEventArgs e)
        {
            imgTransport.Source = null;
            wfCamera camera = new wfCamera();
            camera.ShowDialog();
            if (File.Exists(PathTemp))
            {
                flag = 1;
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                imgTransport.Source = new BitmapImage(new Uri(PathTemp));
            }
            else
            {
                string imgPath = Config.pathPhotoTransports + features.Id + ".jpg";
                imgTransport.Source = new BitmapImage(new Uri(imgPath));
            }
            path = PathTemp;
        }
    }
}
