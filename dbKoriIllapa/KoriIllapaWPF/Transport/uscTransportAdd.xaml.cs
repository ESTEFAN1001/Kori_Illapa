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
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace KoriIllapaWPF.Transport
{
    /// <summary>
    /// Lógica de interacción para uscTransportAdd.xaml
    /// </summary>
    public partial class uscTransportAdd : UserControl
    {
        private string PathTemp = @"C:\KoriIllapa\Images\Temp\temp.jpg";
        string path = "";
        Random random = new Random();
        FeaturesImpl implFeatures;
        Features features;
        Transports transport;
        TransportImpl implTransport;
        byte transportType;
        public uscTransportAdd()
        {
            InitializeComponent();
        }

        private void dgTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTransport.SelectedItem != null && dgTransport.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgTransport.SelectedItem;
                    short id = short.Parse(d.Row.ItemArray[0].ToString());

                    if (id != 0)
                    {
                        string pathCharge = Config.pathPhotoTransports + id + ".jpg";
                        imgEmployeeSelect.Source = new BitmapImage(new Uri(pathCharge));
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
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
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Validaciones
                transportType = byte.Parse(cbxTransporType.SelectedValue.ToString());
                transport = new Transports(txtLicense.Text, transportType);
                features = new Features(short.Parse(txtCapacity.Text), txtColor.Text, txtBrand.Text);
                implFeatures = new FeaturesImpl();
                short id = implTransport.GetGenerateID();

                implFeatures.Insert(transport, features);
                File.Copy(path, Config.pathPhotoTransports + id + ".jpg");
                Select();
                limpiar();
                lblResult.Content = "Se ingreso correctamente";
                #endregion
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error Comuniquese con el Area de Sistemas");
                throw error;
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            FillComboTransport();
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
            imgEmployeeSelect.Source = null;
        }

        private void btnCameraTransport_Click(object sender, RoutedEventArgs e)
        {
            wfCamera camera = new wfCamera();
            camera.ShowDialog();

            imgTransport.Source = new BitmapImage(new Uri(PathTemp));
            path = PathTemp;
        }
    }
}
