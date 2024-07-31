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
    /// Lógica de interacción para firstLogin.xaml
    /// </summary>
    public partial class firstLogin : Window
    {
        EmployeeImpl implEmployee = new EmployeeImpl();
        Employees employees = new Employees();
        public firstLogin()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtNewPassword.Password == txtRepeatNewPassword.Password)
                {
                    int n = implEmployee.firstLogin(txtOldPassword.Password, txtNewPassword.Password);
                    if (n > 0)
                    {
                        txtInfo.Text = "Cambio exitoso";
                        MessageBox.Show("Se cambio la contraseña correctamente", "Kori-Illapa");
                        this.Close();
                    }
                    else
                    {
                        txtInfo.Text = "Su contraseña antigua es incorrecta";
                    }
                }
                else
                {
                    txtInfo.Text = "Reingrese bien la nueva contraseña";
                }  
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
