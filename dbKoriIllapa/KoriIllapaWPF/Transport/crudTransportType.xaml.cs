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
using System.Data;
using System.Text.RegularExpressions;

namespace KoriIllapaWPF.Transport
{
    /// <summary>
    /// Lógica de interacción para crudTransportType.xaml
    /// </summary>
    public partial class crudTransportType : Window
    {
        TransportTypeImpl implType;
        TransportType type;
        byte op = 0;
        public crudTransportType()
        {
            InitializeComponent();
        }
        private void Select()
        {
            implType = new TransportTypeImpl();
            dgType.ItemsSource = null;
            try
            {
                dgType.ItemsSource = implType.Select().DefaultView;
                dgType.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                throw error;
            }
        }
        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        void enabledButtons()
        {
            btnInsert.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            txtTypeName.IsEnabled = true;
            txtTypeName.Focus();
        }
        void disabledButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            txtTypeName.IsEnabled = false;
            txtTypeName.Clear();
            txtTypeName.Focus();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            enabledButtons();
            this.op = 1;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            enabledButtons();
            this.op = 2;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.op)
            {
                case 1:
                    //Insert
                    type = new TransportType(txtTypeName.Text);
                    implType = new TransportTypeImpl();
                    try
                    {
                        #region Validaciones
                        if (Regex.IsMatch(txtTypeName.Text, @"\d"))
                        {
                            lblValidacion.Content = "No puede ingresar numeros";
                        }
                        else
                        {
                            if (Regex.IsMatch(txtTypeName.Text, @"\w{20}"))
                            {
                                lblValidacion.Content = "La cadena no necesita tantos caracteres";
                            }
                            else
                            {
                                if (Regex.IsMatch(txtTypeName.Text, @"\w{5}"))
                                {
                                    if (Regex.IsMatch(txtTypeName.Text, @"\s{2}"))
                                    {
                                        lblValidacion.Content = "La cadena no puede incluir 2 espacios";
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtTypeName.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                        {
                                            lblValidacion.Content = "La cadena no puede incluir caracteres especiales";
                                        }
                                        else
                                        {
                                            lblValidacion.Content = "";
                                            int n = implType.Insert(type);
                                            if (n > 0)
                                            {
                                                lblResult.Content = "Se registro correctamente";
                                                Select();
                                                disabledButtons();
                                            }
                                            else
                                            {
                                                lblResult.Content = "Sucedio un error";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lblValidacion.Content = "La cadena necesita mas caracteres";
                                }

                            }
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                        throw error;
                    }
                    break;
                case 2:
                    //Update
                    type.transporTypeName = txtTypeName.Text;
                    implType = new TransportTypeImpl();
                    try
                    {
                        #region Validaciones
                        if (Regex.IsMatch(txtTypeName.Text, @"\d"))
                        {
                            lblValidacion.Content = "No puede ingresar numeros";
                        }
                        else
                        {
                            if (Regex.IsMatch(txtTypeName.Text, @"\w{20}"))
                            {
                                lblValidacion.Content = "La cadena no necesita tantos caracteres";
                            }
                            else
                            {
                                if (Regex.IsMatch(txtTypeName.Text, @"\w{5}"))
                                {
                                    if (Regex.IsMatch(txtTypeName.Text, @"\s{2}"))
                                    {
                                        lblValidacion.Content = "La cadena no puede incluir 2 espacios";
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtTypeName.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                        {
                                            lblValidacion.Content = "La cadena no puede incluir caracteres especiales";
                                        }
                                        else
                                        {
                                            lblValidacion.Content = "";
                                            int n = implType.Update(type);
                                            if (n > 0)
                                            {
                                                lblResult.Content = "Se actualizo correctamente";
                                                Select();
                                                disabledButtons();
                                            }
                                            else
                                            {
                                                lblResult.Content = "Sucedio un error";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lblValidacion.Content = "La cadena necesita mas caracteres";
                                }

                            }
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                        throw error;
                    }
                    break;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            disabledButtons();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            lblResult.Content = dgType.Items.Count + "Registros encontrados";
        }

        private void dgCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgType.SelectedItem != null && dgType.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgType.SelectedItem;
                    byte id = byte.Parse(d.Row.ItemArray[0].ToString());
                    implType = new TransportTypeImpl();
                    type = implType.Get(id);
                    if (type != null)
                    {
                        txtTypeName.Text = type.transporTypeName;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (type != null)
            {
                if (MessageBox.Show("¿Esta segur@ \n de eliminar el registro?", "KORI_ILLAPA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implType = new TransportTypeImpl();
                        int n = implType.Delete(type);
                        if (n > 0)
                        {
                            lblResult.Content = "Se elimino correctamente";
                            Select();
                            disabledButtons();
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

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Select();
        }
    }
}
