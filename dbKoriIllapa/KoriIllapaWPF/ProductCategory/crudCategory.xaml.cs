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

namespace KoriIllapaWPF.ProductCategory
{
    /// <summary>
    /// Lógica de interacción para crudCategory.xaml
    /// </summary>
    public partial class crudCategory : Window
    {
        CategoryImpl implCategory;
        Category category;
        byte op = 0;
        public crudCategory()
        {
            InitializeComponent();
        }
        private void Select()
        {
            implCategory = new CategoryImpl();
            dgCategory.ItemsSource = null;
            try
            {
                dgCategory.ItemsSource = implCategory.Select().DefaultView;
                dgCategory.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                throw error;
            }
        }
        private void stpClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        void enabledButtons()
        {
            btnInsert.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            txtCategoryName.IsEnabled = true;
            txtCategoryName.Focus();
        }
        void disabledButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            txtCategoryName.IsEnabled = false;
            txtCategoryName.Clear();
            txtCategoryName.Focus();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            enabledButtons();
            this.op = 1;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            enabledButtons();
            this.op = 2;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.op)
            {
                case 1:
                    //Insert
                    category = new Category(txtCategoryName.Text);
                    implCategory = new CategoryImpl();
                    try
                    {
                        #region Validaciones
                        if (Regex.IsMatch(txtCategoryName.Text, @"\d"))
                        {
                            lblValidacion.Content = "No puede ingresar numeros";
                        }
                        else
                        {
                            if (Regex.IsMatch(txtCategoryName.Text, @"\w{20}"))
                            {
                                lblValidacion.Content = "La cadena no necesita tantos caracteres";
                            }
                            else
                            {
                                if (Regex.IsMatch(txtCategoryName.Text, @"\w{5}"))
                                {
                                    if (Regex.IsMatch(txtCategoryName.Text, @"\s{2}"))
                                    {
                                        lblValidacion.Content = "La cadena no puede incluir 2 espacios";
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtCategoryName.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|-|_]"))
                                        {
                                            lblValidacion.Content = "La cadena no puede incluir caracteres especiales";
                                        }
                                        else
                                        {
                                            lblValidacion.Content = "";
                                            int n = implCategory.Insert(category);
                                            if (n > 0)
                                            {
                                                lblResult.Content = "Se registro correctamente";
                                                Select();
                                                disabledButtons();
                                            }
                                            else
                                            {
                                                lblResult.Content = "Sucedio un error";
                                            }
                                        }  
                                    }
                                }
                                else
                                {
                                    lblValidacion.Content = "La cadena necesita mas caracteres";
                                }
                                
                            }
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                        throw error;
                    }
                    break;
                case 2:
                    //Update
                    category.categoryName = txtCategoryName.Text;
                    implCategory = new CategoryImpl();
                    try
                    {
                        #region Validaciones
                        if (Regex.IsMatch(txtCategoryName.Text, @"\d"))
                        {
                            lblValidacion.Content = "No puede ingresar numeros";
                        }
                        else
                        {
                            if (Regex.IsMatch(txtCategoryName.Text, @"\w{20}"))
                            {
                                lblValidacion.Content = "La cadena no necesita tantos caracteres";
                            }
                            else
                            {
                                if (Regex.IsMatch(txtCategoryName.Text, @"\w{5}"))
                                {
                                    if (Regex.IsMatch(txtCategoryName.Text, @"\s{2}"))
                                    {
                                        lblValidacion.Content = "La cadena no puede incluir 2 espacios";
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtCategoryName.Text, @"[@|.|#|!|<|>|@|~$|%|&|(|)|=|?|¿|¡|*|:|;|,|_]"))
                                        {
                                            lblValidacion.Content = "La cadena no puede incluir caracteres especiales";
                                        }
                                        else
                                        {
                                            lblValidacion.Content = "";
                                            int n = implCategory.Update(category);
                                            if (n > 0)
                                            {
                                                lblResult.Content = "Se actualizo correctamente";
                                                Select();
                                                disabledButtons();
                                            }
                                            else
                                            {
                                                lblResult.Content = "Sucedio un error";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lblValidacion.Content = "La cadena necesita mas caracteres";
                                }

                            }
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                        throw error;
                    }
                    break;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            disabledButtons();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            lblResult.Content = dgCategory.Items.Count + " Registros encontrados";
        }

        private void dgCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgCategory.SelectedItem != null && dgCategory.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgCategory.SelectedItem;
                    byte id = byte.Parse(d.Row.ItemArray[0].ToString());
                    implCategory = new CategoryImpl();
                    category = implCategory.Get(id);
                    if(category != null)
                    {
                        txtCategoryName.Text = category.categoryName;
                    }
                }
                catch(Exception error)
                {
                    MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                    throw error;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(category != null)
            {
                if (MessageBox.Show("¿Esta segur@ \n de eliminar el registro?", "KORI_ILLAPA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implCategory = new CategoryImpl();
                        int n = implCategory.Delete(category);
                        if (n > 0)
                        {
                            lblResult.Content = "Se elimino correctamente";
                            Select();
                            disabledButtons();
                        }
                        else
                        {
                            lblResult.Content = "Sucedio un error";
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ejecutar la transaccion\nComuniquese con el area de sistemas ", "KORI-ILLAPA");
                        throw error;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar");
            }
        }
    }
}
