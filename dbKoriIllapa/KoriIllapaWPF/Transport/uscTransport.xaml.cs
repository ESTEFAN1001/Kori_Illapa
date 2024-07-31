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

namespace KoriIllapaWPF.Transport
{
    /// <summary>
    /// Lógica de interacción para uscTransport.xaml
    /// </summary>
    public partial class uscTransport : UserControl
    {
        public uscTransport()
        {
            InitializeComponent();
        }

        private void cardType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            crudTransportType transportType = new crudTransportType();
            transportType.ShowDialog();
        }

        private void cardTransport_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            crudTransport transport = new crudTransport();
            transport.ShowDialog();
        }

        private void cardSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            searchTransport search = new searchTransport();
            search.ShowDialog();
        }
    }
}
