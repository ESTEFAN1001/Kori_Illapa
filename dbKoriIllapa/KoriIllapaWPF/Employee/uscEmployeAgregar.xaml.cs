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
    /// Lógica de interacción para uscEmployeAgregar.xaml
    /// </summary>
    public partial class uscEmployeAgregar : UserControl
    {
        string path = "";
        string rol = "";
        Random random = new Random();
        EmployeeImpl implEmployee;
        Employees employees;
        public uscEmployeAgregar()
        {
            InitializeComponent();
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

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            
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
                                                                                                                    int op = cbxRol.SelectedIndex;
                                                                                                                    if (op == 0)
                                                                                                                        rol = "Administrador";
                                                                                                                    if (op == 1)
                                                                                                                        rol = "Monitor";
                                                                                                                    if (op == 2)
                                                                                                                        rol = "Transporte";
                                                                                                                    if(path != "")
                                                                                                                    {
                                                                                                                        string userName = "";
                                                                                                                        string gen = txtSurname.Text + txtLastname.Text + txtPhone.Text;
                                                                                                                        gen.ToLower();
                                                                                                                        gen.ToCharArray();
                                                                                                                        for (int i = 0; i < gen.Length; i++)
                                                                                                                        {
                                                                                                                            if ((i % 2) == 0)
                                                                                                                            {
                                                                                                                                userName += gen[i];
                                                                                                                            }
                                                                                                                        }
                                                                                                                        string password = random.Next(10000000, 99999999).ToString();

                                                                                                                        Logic logic = new Logic();
                                                                                                                        string sms = logic.emailSend(txtEmail.Text, "Datos de Sesion", "Nombre de Usuario: " + userName + "\nContraseña: " + password);

                                                                                                                        employees = new Employees(txtName.Text, txtSurname.Text, txtLastname.Text, txtDirection.Text, int.Parse(txtPhone.Text), rol, userName, password, txtEmail.Text);
                                                                                                                        short id = implEmployee.GetGenerateID();
                                                                                                                        int n = implEmployee.Insert(employees);

                                                                                                                        if (n > 0)
                                                                                                                        {
                                                                                                                            lblResult.Content = "Se registro correctamente";
                                                                                                                            File.Copy(path, Config.pathPhotoEmployees+id+".jpg");
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
                                                                                                                        lblResult.Content = "Debe ingresar una imagen";
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
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    lblResult.Content = "La cadena necesita mas caracteres";
                                                                                }

                                                                            }

                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    lblResult.Content = "La cadena necesita mas caracteres";
                                                                }

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lblResult.Content = "La cadena necesita mas caracteres";
                                            }

                                        }
                                    }
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbxRol.SelectedIndex = 0;
            Select();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
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
            imgEmployeeSelect.Source = null;
        }
        private void cbxRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
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
                        string pathCharge = Config.pathPhotoEmployees + employees.id + ".jpg";
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

        private void btnImageEmployee_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivos de Imagen|*.jpg";
            if(file.ShowDialog() == true)
            {
                path = file.FileName;
                imgEmployee.Source = new BitmapImage(new Uri(path));
            }
        }
    }
}
