using System;
using System.Collections.Generic;
using System.Data;
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
using KoriIllapaDAO.Implementation;
using KoriIllapaDAO.Model;

namespace KoriIllapaWPF
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            EmployeeImpl implEmployee = new EmployeeImpl();
            ConfigImpl implConfig = new ConfigImpl();
            try
            {
                DataTable table = new DataTable();
                table = implEmployee.Login(txtUserName.Text, pwbPassword.Password);
                if(table.Rows.Count > 0)
                {
                    Session.SessionUserId = byte.Parse(table.Rows[0][0].ToString());
                    Session.SessionUserName = table.Rows[0][1].ToString();
                    Session.SessionUserRol = table.Rows[0][2].ToString();
                    Session.SessionUserStatus = byte.Parse(table.Rows[0][3].ToString());

                    //Variables globales 

                    DataTable tableConfig = implConfig.Select();
                    Config.pathPhotoEmployees = tableConfig.Rows[0][0].ToString();
                    Config.pathPhotoSuppliers = tableConfig.Rows[0][1].ToString();
                    Config.pathPhotoTransports = tableConfig.Rows[0][2].ToString();

                    if(Session.SessionUserStatus == 0)
                    {
                        txtUserName.Text = "";
                        pwbPassword.Password = "";
                        firstLogin first = new firstLogin();
                        first.stpClose.Visibility = Visibility.Hidden;
                        first.ShowDialog();
                    }
                    else
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    txtInfo.Text = "Usuario y/o contraseña incorrectos";
                }
            }catch(Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void lblForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            forgotPassword forgot = new forgotPassword();
            forgot.ShowDialog();
        }
    }
}
