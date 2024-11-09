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
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace TECH_STORE
{
    /// <summary>
    /// Interaction logic for ProductScreem.xaml
    /// </summary>
    public partial class ProductScreen : Window
    {
        
        public ProductScreen()
        {
            InitializeComponent();
            Main.Content = new ProductList();
        }


        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProductList();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OrderPage();
        }
    }
}
