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

namespace WpfDataBindingDataBase
{
    /// <summary>
    /// Interaction logic for BindingDataBaseWiev.xaml
    /// </summary>
    public partial class BindingDataBaseWiev : Window
    {
        public BindingDataBaseWiev()
        {
            InitializeComponent();
        }


        NorthWnidDataSetTableAdapters.OrdersTableAdapter _orders = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var northwindDataSet = new NorthWnidDataSet();
            var customersTableAdapter = new NorthWnidDataSetTableAdapters.CustomersTableAdapter();
            customersTableAdapter.Fill(northwindDataSet.Customers);
            listBox.ItemsSource = northwindDataSet.Customers;
            _orders = new NorthWnidDataSetTableAdapters.OrdersTableAdapter();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ordersTextBox.Text = _orders.orderCount(
                
                ((NorthWnidDataSet.CustomersRow)((DataRowView)((ListBox)sender).SelectedItem).Row).CustomerID
                
                ).ToString();
        }
    }
}
