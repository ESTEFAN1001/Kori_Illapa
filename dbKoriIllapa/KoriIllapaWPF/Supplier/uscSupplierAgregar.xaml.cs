using Microsoft.Maps.MapControl.WPF;
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
using KoriIllapaDAO.Implementation;
using KoriIllapaDAO.Model;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace KoriIllapaWPF.Supplier
{
    /// <summary>
    /// Lógica de interacción para uscSupplierAgregar.xaml
    /// </summary>
    public partial class uscSupplierAgregar : UserControl
    {
        Location point;
        string path = "";
        Random random = new Random();
        SupplierImpl implSupplier;
        Suppliers suppliers;
        byte departament;
        byte doubleClick = 0;
        public uscSupplierAgregar()
        {
            InitializeComponent();
        }
        private void Select()
        {
            implSupplier = new SupplierImpl();
            dgSupplier.ItemsSource = null;
            try
            {
                dgSupplier.ItemsSource = implSupplier.Select().DefaultView;
                dgSupplier.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                throw error;
            }
        }
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                #region Validaciones
                if (path != "")
                {
                    if(doubleClick == 1)
                    {
                        if (Regex.IsMatch(txtPhone.Text, @"\w[a-z]"))
                        {
                            lblResult.Content = "El campo numero no debe tener letras";
                        }
                        else
                        {
                            if (Regex.IsMatch(txtPhone.Text, @"\d{8}"))
                            {
                                if (Regex.IsMatch(txtPhone.Text, @"\d{9}"))
                                {
                                    lblResult.Content = "Demasiados Numeros";
                                }
                                else
                                {
                                    if (Regex.IsMatch(txtPhone.Text, @"\s{2}"))
                                    {
                                        lblResult.Content = "El numero no puede incluir 2 espacios";
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtPhone.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                        {
                                            lblResult.Content = "El numero no puede incluir caracteres especiales";
                                        }
                                        else
                                        {

                                            if (Regex.IsMatch(txtEmail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                                                    + "@"
                                                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
                                            {

                                                if (Regex.IsMatch(txtName.Text, @"\s{2}"))
                                                {
                                                    lblResult.Content = "La cadena no puede incluir 2 espacios";
                                                }
                                                else
                                                {
                                                    if (Regex.IsMatch(txtName.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                                    {
                                                        lblResult.Content = "La cadena no puede incluir caracteres especiales";
                                                    }
                                                    else
                                                    {
                                                        if (Regex.IsMatch(txtName.Text, @"\d"))
                                                        {
                                                            lblResult.Content = "No puede ingresar numeros";
                                                        }
                                                        else
                                                        {
                                                            if(txtName.Text.Length > 3)
                                                            {
                                                                departament = byte.Parse(cbxDepartament.SelectedValue.ToString());
                                                                suppliers = new Suppliers(txtName.Text, int.Parse(txtPhone.Text), float.Parse(point.Latitude.ToString()), float.Parse(point.Longitude.ToString()), txtEmail.Text, departament);
                                                                short id = implSupplier.GetGenerateID();
                                                                int n = implSupplier.Insert(suppliers);

                                                                if (n > 0)
                                                                {
                                                                    lblResult.Content = "Se registro correctamente";
                                                                    File.Copy(path, Config.pathPhotoSuppliers + id + ".jpg");
                                                                    //File.Copy(path, "C://KoriIllapa//otros//" + id + ".jpg");

                                                                    Select();
                                                                    limpiar();
                                                                }
                                                                else
                                                                {
                                                                    lblResult.Content = "Sucedio un error";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lblResult.Content = "Caracteres Insuficientes";
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lblResult.Content = "Ingrese un correo valido";
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                lblResult.Content = "Numeros insuficientes";
                            }
                        }
                    }
                    else
                    {
                        lblResult.Content = "Seleccione un lugar en el mapa";
                    }
                }
                else
                {
                    lblResult.Content = "Seleccione una Imagen";
                }
                #endregion
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas " + error.Message, "KORI-ILLAPA");
                throw error;
            }
        }

        private void dgSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mapSupplier.Children.Clear();
            if (dgSupplier.SelectedItem != null && dgSupplier.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgSupplier.SelectedItem;
                    short id = short.Parse(d.Row.ItemArray[0].ToString());
                    implSupplier = new SupplierImpl();
                    suppliers = implSupplier.Get(id);

                    if (suppliers != null)
                    {
                        string pathCharge = Config.pathPhotoSuppliers + suppliers.id + ".jpg";
                        imgSupplierSelect.Source = new BitmapImage(new Uri(pathCharge));
                        Pushpin pin1 = new Pushpin();
                        Location point1 = new Location();
                        point1.Latitude = suppliers.latitud;
                        point1.Longitude = suppliers.longitud;
                        point = point1;
                        pin1.Location = point1;
                        mapSupplier.Children.Add(pin1);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void btnImageSupplier_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivos de Imagen|*.jpg";
            if (file.ShowDialog() == true)
            {
                path = file.FileName;
                imgSupplier.Source = new BitmapImage(new Uri(path));
            }
        }

        private void btnSatelite_Click(object sender, RoutedEventArgs e)
        {
            mapSupplier.Focus();
            mapSupplier.Mode = new AerialMode(true);
        }

        private void btnStreet_Click(object sender, RoutedEventArgs e)
        {
            mapSupplier.Focus();
            mapSupplier.Mode = new RoadMode();
        }

        private void sldZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mapSupplier.Focus();
            mapSupplier.ZoomLevel = sldZoom.Value;
        }

        private void mapSupplier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            doubleClick = 1;
            e.Handled = true;
            var mousePosition = e.GetPosition((UIElement)sender);
            point = mapSupplier.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = point;
            mapSupplier.Children.Clear();
            mapSupplier.Children.Add(pin);
        }
        void limpiar()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            imgSupplier.Source = null;
            imgSupplierSelect.Source = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboAirline();
            Select();
        }
        void FillComboAirline()
        {
            implSupplier = new SupplierImpl();
            try
            {
                cbxDepartament.ItemsSource = null;
                cbxDepartament.DisplayMemberPath = "departamentName";
                cbxDepartament.SelectedValuePath = "idDepartament";
                cbxDepartament.ItemsSource = implSupplier.SelectComboSupplier().DefaultView;
                cbxDepartament.SelectedIndex = 0;
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}
