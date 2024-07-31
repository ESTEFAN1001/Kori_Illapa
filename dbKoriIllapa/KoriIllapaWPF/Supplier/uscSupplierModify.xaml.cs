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
using KoriIllapaDAO.Model;
using KoriIllapaDAO.Implementation;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace KoriIllapaWPF.Supplier
{
    /// <summary>
    /// Lógica de interacción para uscSupplierModify.xaml
    /// </summary>
    public partial class uscSupplierModify : UserControl
    {
        Location point;
        string path = "";
        SupplierImpl implSupplier;
        Suppliers suppliers;
        byte departament;
        public uscSupplierModify()
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
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            departament = byte.Parse(cbxDepartament.SelectedValue.ToString());

            suppliers.supplierName = txtName.Text;
            suppliers.phone = int.Parse(txtPhone.Text);
            suppliers.email = txtEmail.Text;
            suppliers.latitud = float.Parse(point.Latitude.ToString());
            suppliers.longitud = float.Parse(point.Longitude.ToString());
            suppliers.departament = departament;
            try
            {
                #region Validaciones
                if (path != "")
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
                                                            if (txtName.Text.Length > 3)
                                                            {
                                                                int n = implSupplier.Update(suppliers);
                                                                
                                                                if (n > 0)
                                                                {
                                                                    DataRowView d = (DataRowView)dgSupplier.SelectedItem;
                                                                    short id = short.Parse(d.Row.ItemArray[0].ToString());
                                                                    implSupplier = new SupplierImpl();
                                                                    suppliers = implSupplier.Get(id);
                                                                    
                                                                    System.GC.Collect();
                                                                    System.GC.WaitForPendingFinalizers();
                                                                    
                                                                    File.Delete(Config.pathPhotoSuppliers + suppliers.id + ".jpg");
                                                                    File.Copy(path, Config.pathPhotoSuppliers + suppliers.id + ".jpg");

                                                                    lblResult.Content = "Se actualizo correctamente";
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (suppliers != null)
            {
                if (MessageBox.Show("¿Esta segur@ \n de eliminar el registro?", "KORI_ILLAPA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implSupplier = new SupplierImpl();
                        int n = implSupplier.Delete(suppliers);
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

        private void dgSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSupplier.SelectedItem != null && dgSupplier.Items.Count > 0)
            {
                try
                {
                    mapSupplier.Children.Clear();
                    departament = byte.Parse(cbxDepartament.SelectedValue.ToString());
                    DataRowView d = (DataRowView)dgSupplier.SelectedItem;
                    short id = short.Parse(d.Row.ItemArray[0].ToString());
                    implSupplier = new SupplierImpl();
                    suppliers = implSupplier.Get(id);

                    if (suppliers != null)
                    {
                        txtName.Text = suppliers.supplierName;
                        cbxDepartament.SelectedIndex = suppliers.departament - 1;
                        txtPhone.Text = suppliers.phone.ToString();
                        txtEmail.Text = suppliers.email;
                        Pushpin pin1 = new Pushpin();
                        Location point1 = new Location();
                        point1.Latitude = suppliers.latitud;
                        point1.Longitude = suppliers.longitud;
                        point = point1;
                        pin1.Location = point1;
                        mapSupplier.Children.Add(pin1);

                        string pathCharge = Config.pathPhotoSuppliers + suppliers.id + ".jpg";
                        imgSupplier.Source = new BitmapImage(new Uri(pathCharge));

                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
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

        private void mapSupplier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousePosition = e.GetPosition((UIElement)sender);
            point = mapSupplier.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = point;
            mapSupplier.Children.Clear();
            mapSupplier.Children.Add(pin);
        }

        private void btnStreet_Click(object sender, RoutedEventArgs e)
        {
            mapSupplier.Focus();
            mapSupplier.Mode = new RoadMode();
        }

        private void btnSatelite_Click(object sender, RoutedEventArgs e)
        {
            mapSupplier.Focus();
            mapSupplier.Mode = new AerialMode(true);
        }

        private void sldZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mapSupplier.Focus();
            mapSupplier.ZoomLevel = sldZoom.Value;
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
        void limpiar()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            imgSupplier.Source = null;
            cbxDepartament.SelectedIndex = 0;
            mapSupplier.Children.Clear();
        }
    }
}
