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

namespace KoriIllapaWPF.Employee
{
    /// <summary>
    /// Lógica de interacción para uscEmployee.xaml
    /// </summary>
    public partial class uscEmployee : UserControl
    {
        public uscEmployee()
        {
            InitializeComponent();
        }

        private void cardEmployees_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            crudEmployee employee = new crudEmployee();
            employee.ShowDialog();
        }
    }
}
