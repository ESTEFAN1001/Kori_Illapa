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

namespace KoriIllapaWPF.ProductCategory
{
    /// <summary>
    /// Lógica de interacción para ProductCategory.xaml
    /// </summary>
    public partial class ProductCategory : UserControl
    {
        public ProductCategory()
        {
            InitializeComponent();
        }

        private void cardCategory_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            crudCategory category = new crudCategory();
            category.ShowDialog();
        }
    }
}
