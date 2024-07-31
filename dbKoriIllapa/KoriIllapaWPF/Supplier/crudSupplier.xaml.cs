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

namespace KoriIllapaWPF.Supplier
{
    /// <summary>
    /// Lógica de interacción para crudSupplier.xaml
    /// </summary>
    public partial class crudSupplier : Window
    {
        public crudSupplier()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            UserControl user = null;
            gridOptionSupplier.Children.Clear();
            user = new Supplier.uscSupplierAgregar();

            gridOptionSupplier.Children.Add(user);
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            UserControl user = null;
            gridOptionSupplier.Children.Clear();
            user = new Supplier.uscSupplierModify();

            gridOptionSupplier.Children.Add(user);
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
