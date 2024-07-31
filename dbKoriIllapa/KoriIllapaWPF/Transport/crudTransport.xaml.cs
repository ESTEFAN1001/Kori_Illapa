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

namespace KoriIllapaWPF.Transport
{
    /// <summary>
    /// Lógica de interacción para crudTransport.xaml
    /// </summary>
    public partial class crudTransport : Window
    {
        public crudTransport()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            UserControl trans = null;
            gridOptionTransport.Children.Clear();
            trans = new Transport.uscTransportAdd();

            gridOptionTransport.Children.Add(trans);
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            UserControl trans = null;
            gridOptionTransport.Children.Clear();
            trans = new Transport.uscTransportMod();

            gridOptionTransport.Children.Add(trans);
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
