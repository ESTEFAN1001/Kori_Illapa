using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace KoriIllapaWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    ////
    public partial class MainWindow : Window
    {
        public delegate void delegadoImagen();
        string path = "";
        MediaPlayer sound = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            delegadoImagen img = hide;
            img += show;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void imgUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgBelow.Visibility = Visibility.Visible;
            imgUp.Visibility = Visibility.Collapsed;
        }

        private void imgBelow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgBelow.Visibility = Visibility.Collapsed;
            imgUp.Visibility = Visibility.Visible;
        }

        private void lvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            imgBelow.Visibility = Visibility.Collapsed;
            imgUp.Visibility = Visibility.Visible;
            UserControl user = null;
            gridUsserControl.Children.Clear();

            switch (((ListViewItem)(((ListView)sender).SelectedItem)).Name)
            {
                case "itemHome":
                    user = new Main.Home();
                    break;
                case "itemProdCat":
                    user = new ProductCategory.ProductCategory();
                    break;
                case "itemTransporte":
                    user = new Transport.uscTransport();
                    break;
                case "itemEmployee":
                    user = new Employee.uscEmployee();
                    break;
                case "itemSupplier":
                    user = new Supplier.uscSupplier();
                    break;
            }
            if(user != null)
            {
                gridUsserControl.Children.Add(user);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            path = Config.pathPhotoEmployees + Session.SessionUserId + ".jpg";
            imgLoginUser.Source = new BitmapImage(new Uri(path));

            //se debe cambiar despues del login
            txbSessionUser.Text = "" + Session.SessionUserName + ": \n" + Session.SessionUserRol;
            switch (Session.SessionUserRol)
            {
                case "Administrador":
                    itemProdCat.Visibility = Visibility.Collapsed;
                    break;
                case "Transporte":
                    itemEmployee.Visibility = Visibility.Collapsed;
                    itemProdCat.Visibility = Visibility.Collapsed;
                    itemClients.Visibility = Visibility.Collapsed;
                    itemSupplier.Visibility = Visibility.Collapsed;
                    break;
                case "Monitor":
                    itemEmployee.Visibility = Visibility.Collapsed;
                    itemTransporte.Visibility = Visibility.Collapsed;
                    break;
            }
            musica();
            sound.Play();
        }
        private void musica()
        {
            sound.Open(new Uri(@"C:\Users\ASUS\OneDrive - Universidad Privada del Valle\Documents\Avatar\Abecedario\rebelde.mp3", UriKind.Relative));
            sound.Volume = 0.90;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            //forgotPassword forgot = new forgotPassword();
            //forgot.ShowDialog();
            firstLogin first = new firstLogin();
            first.ShowDialog();
        }
        
        void hide() 
        {
            imgLoginUser.Source = null;
        }
        void show()
        {
            path = Config.pathPhotoEmployees + Session.SessionUserId + ".jpg";
            imgLoginUser.Source = new BitmapImage(new Uri(path));
        }
    }
}
