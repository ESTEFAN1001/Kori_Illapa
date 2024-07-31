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

namespace KoriIllapaWPF
{
    /// <summary>
    /// Lógica de interacción para forgotPassword.xaml
    /// </summary>
    public partial class forgotPassword : Window
    {
        Random random = new Random();
        EmployeeImpl implEmployee = new EmployeeImpl();
        Employees employees = new Employees();
        int code;
        public forgotPassword()
        {
            InitializeComponent();
        }

        private void btnRestorePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(int.Parse(pwbAutentify.Password) == code)
                {
                    int n = implEmployee.forgotPassword(txtUserName.Text, txtEmail.Text, pwbNewPassword.Password);
                    if (n > 0)
                    {
                        txtInfo.Text = "Restablecimiento exitoso";
                        this.Close();
                    }
                    else
                    {
                        txtInfo.Text = "Sucedio un error";
                    }
                }
                else
                {
                    txtInfo.Text = "Revise el codigo";
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void btnSendCode_Click(object sender, RoutedEventArgs e)
        {
            EmployeeImpl implEmployee = new EmployeeImpl();
            try
            {
                DataTable table = new DataTable();
                table = implEmployee.valEmail(txtEmail.Text);
                if (table.Rows.Count > 0)
                {
                    txtUserName.IsEnabled = true;
                    txtEmail.IsEnabled = true;
                    pwbAutentify.IsEnabled = true;
                    pwbNewPassword.IsEnabled = true;
                    btnRestorePassword.IsEnabled = true;

                    code = random.Next(1000, 9999);
                    Logic logic = new Logic();
                    string sms = logic.emailSend(txtEmail.Text, "Codigo de Autentificacion", "Codigo: " + code);
                }
                else
                {
                    txtInfo.Text = "Ingrese un usuario valido";
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
            
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
