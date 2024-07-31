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

namespace KoriIllapaWPF.Employee
{
    /// <summary>
    /// Lógica de interacción para crudEmployee.xaml
    /// </summary>
    public partial class crudEmployee : Window
    {
        public crudEmployee()
        {
            InitializeComponent();
        }

        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            UserControl user = null;
            gridOptionEmployee.Children.Clear();
            user = new Employee.uscEmployeAgregar();

            gridOptionEmployee.Children.Add(user);
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            UserControl user = null;
            gridOptionEmployee.Children.Clear();
            user = new Employee.uscEmployeeUpdateDelete();

            gridOptionEmployee.Children.Add(user);
        }
    }
}
