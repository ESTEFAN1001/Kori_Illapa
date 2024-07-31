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

namespace KoriIllapaWPF.Employee
{
    /// <summary>
    /// Lógica de interacción para uscEmployeeUpdateDelete.xaml
    /// </summary>
    public partial class uscEmployeeUpdateDelete : UserControl
    {
        public delegate void delegado();
        OpenFileDialog file = new OpenFileDialog();
        string path = "";
        EmployeeImpl implEmployee;
        Employees employees;
        public uscEmployeeUpdateDelete()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            employees.name = txtName.Text;
            employees.surname = txtSurname.Text;
            employees.lastname = txtLastname.Text;
            employees.direction = txtDirection.Text;
            employees.phone = int.Parse(txtPhone.Text);
            employees.email = txtEmail.Text;

            implEmployee = new EmployeeImpl();
            try
            {
                //Validaciones
                #region Validaciones
                if (Regex.IsMatch(txtName.Text, @"\d"))
                {
                    lblResult.Content = "No puede ingresar numeros";
                }
                else
                {
                    if (Regex.IsMatch(txtName.Text, @"\w{20}"))
                    {
                        lblResult.Content = "La cadena no necesita tantos caracteres";
                    }
                    else
                    {
                        if (Regex.IsMatch(txtName.Text, @"\w{5}"))
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
                                    #region Validaciones_txtLastname
                                    if (Regex.IsMatch(txtLastname.Text, @"\d"))
                                    {
                                        lblResult.Content = "No puede ingresar numeros";
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtLastname.Text, @"\w{20}"))
                                        {
                                            lblResult.Content = "La cadena no necesita tantos caracteres";
                                        }
                                        else
                                        {
                                            if (Regex.IsMatch(txtLastname.Text, @"\w{5}"))
                                            {
                                                if (Regex.IsMatch(txtLastname.Text, @"\s{2}"))
                                                {
                                                    lblResult.Content = "La cadena no puede incluir 2 espacios";
                                                }
                                                else
                                                {
                                                    if (Regex.IsMatch(txtLastname.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                                    {
                                                        lblResult.Content = "La cadena no puede incluir caracteres especiales";
                                                    }
                                                    else
                                                    {
                                                        #region Validaciones_txtSurname
                                                        if (Regex.IsMatch(txtSurname.Text, @"\d"))
                                                        {
                                                            lblResult.Content = "No puede ingresar numeros";
                                                        }
                                                        else
                                                        {
                                                            if (Regex.IsMatch(txtSurname.Text, @"\w{20}"))
                                                            {
                                                                lblResult.Content = "La cadena no necesita tantos caracteres";
                                                            }
                                                            else
                                                            {
                                                                if (Regex.IsMatch(txtSurname.Text, @"\w{5}"))
                                                                {
                                                                    if (Regex.IsMatch(txtSurname.Text, @"\s{2}"))
                                                                    {
                                                                        lblResult.Content = "La cadena no puede incluir 2 espacios";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Regex.IsMatch(txtSurname.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                                                        {
                                                                            lblResult.Content = "La cadena no puede incluir caracteres especiales";
                                                                        }
                                                                        else
                                                                        {
                                                                            #region Validaciones_txtDirection
                                                                            
                                                                                if (Regex.IsMatch(txtSurname.Text, @"\w{50}"))
                                                                                {
                                                                                    lblResult.Content = "La cadena no necesita tantos caracteres";
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Regex.IsMatch(txtSurname.Text, @"\w{3}"))
                                                                                    {
                                                                                        if (Regex.IsMatch(txtSurname.Text, @"\s{2}"))
                                                                                        {
                                                                                            lblResult.Content = "La cadena no puede incluir 2 espacios";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (Regex.IsMatch(txtSurname.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                                                                            {
                                                                                                lblResult.Content = "La cadena no puede incluir caracteres especiales";
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                #region Validacion_txtPhone
                                                                                                    if(Regex.IsMatch(txtPhone.Text, @"\w[a-z]"))
                                                                                                    {
                                                                                                        lblResult.Content = "El campo numero no debe tener letras";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if(Regex.IsMatch(txtPhone.Text, @"\d{8}"))
                                                                                                        {
                                                                                                            if (Regex.IsMatch(txtPhone.Text, @"\d{9}"))
                                                                                                            {
                                                                                                                lblResult.Content = "Demasiados Caracteres";
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
                                                                                                                            int n = implEmployee.Update(employees);

                                                                                                                            if (n > 0)
                                                                                                                            {
                                                                                                                                DataRowView d = (DataRowView)dgEmployee.SelectedItem;
                                                                                                                                short id = short.Parse(d.Row.ItemArray[0].ToString());
                                                                                                                                implEmployee = new EmployeeImpl();
                                                                                                                                employees = implEmployee.Get(id);

                                                                                                                                System.GC.Collect();
                                                                                                                                System.GC.WaitForPendingFinalizers();
                                                                                                                                
                                                                                                                                File.Delete(Config.pathPhotoEmployees + employees.id + ".jpg");
                                                                                                                                File.Copy(path, Config.pathPhotoEmployees + employees.id + ".jpg"); 

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
                                                                                                                            lblResult.Content = "Ingrese un correo valido";
                                                                                                                        }
                                                                                                                    }
                                                                                                                }

                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            lblResult.Content = "Caracteres insuficientes";
                                                                                                        }
                                                                                                    }
                                                                                                #endregion
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        lblResult.Content = "La cadena necesita mas caracteres";
                                                                                    }

                                                                                }
                                                                            #endregion
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    lblResult.Content = "La cadena necesita mas caracteres";
                                                                }

                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lblResult.Content = "La cadena necesita mas caracteres";
                                            }

                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                        else
                        {
                            lblResult.Content = "La cadena necesita mas caracteres";
                        }

                    }
                }
                #endregion
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas " + error.Message, "KORI-ILLAPA");
                throw error;
            }
        }
        private void Select()
        {
            implEmployee = new EmployeeImpl();
            dgEmployee.ItemsSource = null;
            try
            {
                dgEmployee.ItemsSource = implEmployee.Select().DefaultView;
                dgEmployee.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                throw error;
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (employees != null)
            {
                if (MessageBox.Show("¿Esta segur@ \n de eliminar el registro?", "KORI_ILLAPA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implEmployee = new EmployeeImpl();
                        int n = implEmployee.Delete(employees);
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
        void limpiar()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtLastname.Text = "";
            txtDirection.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            imgEmployee.Source = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            lblResult.Content = dgEmployee.Items.Count + " Registros encontrados";
        }

        private void dgEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEmployee.SelectedItem != null && dgEmployee.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgEmployee.SelectedItem;
                    short id = short.Parse(d.Row.ItemArray[0].ToString());
                    implEmployee = new EmployeeImpl();
                    employees = implEmployee.Get(id);

                    if (employees != null)
                    {
                        txtName.Text = employees.name;
                        txtSurname.Text = employees.surname;
                        txtLastname.Text = employees.lastname;
                        txtDirection.Text = employees.direction;
                        txtPhone.Text = employees.phone.ToString();
                        txtEmail.Text = employees.email;

                        string pathCharge = Config.pathPhotoEmployees + employees.id + ".jpg";
                        imgEmployee.Source = new BitmapImage(new Uri(pathCharge));
                        
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
        }

        private void btnImageEmployee_Click(object sender, RoutedEventArgs e)
        {
            file.Filter = "Archivos de Imagen|*.jpg";
            if (file.ShowDialog() == true)
            {
                path = file.FileName;
                imgEmployee.Source = new BitmapImage(new Uri(path));
            }
        }
    }
}
