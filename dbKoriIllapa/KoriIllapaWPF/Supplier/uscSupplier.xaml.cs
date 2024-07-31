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

namespace KoriIllapaWPF.Supplier
{
    /// <summary>
    /// Lógica de interacción para uscSupplier.xaml
    /// </summary>
    public partial class uscSupplier : UserControl
    {
        public uscSupplier()
        {
            InitializeComponent();
        }

        private void cardSupplier_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            crudSupplier sup = new crudSupplier();
            sup.ShowDialog();
        }
    }
}
