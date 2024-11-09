using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using Tech_BussinessObjects;
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace TECH_STORE
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        private IProductService _productService;
        private Product chosenProduct = null;
        List<Category> categories = new List<Category>
        {
            new Category { Id = 1, CategoryName = "Electronics" },
            new Category { Id = 2, CategoryName = "Home Appliances" },
            new Category { Id = 3, CategoryName = "Computers & Accessories" },
            new Category { Id = 4, CategoryName = "Smart Devices" },
            new Category { Id = 5, CategoryName = "Gaming" }
        };
        public ProductList()
        {
            InitializeComponent();
            _productService = new ProductService();
            cbCategory.ItemsSource = categories;
            cbCategory.SelectedValuePath = "Id";
            cbCategory.DisplayMemberPath = "CategoryName";
        }

        private void LoadProduct()
        {
            var productList = _productService.GetProducts();
            dtgProductList.Columns.Clear();

            dtgProductList.Columns.Add(new DataGridTextColumn
            {
                Header = "ID",
                Binding = new Binding("Id")
            });

            dtgProductList.Columns.Add(new DataGridTextColumn
            {
                Header = "Product Name",
                Binding = new Binding("ProductName")
            });

            dtgProductList.Columns.Add(new DataGridTextColumn
            {
                Header = "Description",
                Binding = new Binding("Description")
            });

            dtgProductList.Columns.Add(new DataGridTextColumn
            {
                Header = "Price",
                Binding = new Binding("Price")
            });

            dtgProductList.Columns.Add(new DataGridTextColumn
            {
                Header = "Quantity",
                Binding = new Binding("Quantity")
            });

            dtgProductList.Columns.Add(new DataGridTextColumn
            {
                Header = "Category",
                Binding = new Binding("Category.CategoryName")
            });

            dtgProductList.ItemsSource = productList;
        }

        private void pgProductList_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProduct();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetProductInfo(Product product)
        {
            if (product == null) {
                return;
            }
            txtProductName.Text = product.ProductName;
            txtPrice.Text = product.Price.ToString();
            txtQuantity.Text = product.Quantity.ToString();
            txtDescription.Text = product.Description;
            cbCategory.SelectedValue = product.CategoryId;
        }

        private Product GetProductInfo()
        {
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                txtPrice.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Text = "0";
            }
            Product product = new Product()
            {
                ProductName = txtProductName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
                CategoryId = (int) cbCategory.SelectedValue,
                CreatedAt = DateTime.Now
            };
            return product;
        }

        private void dtgProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                chosenProduct = (Product) dtgProductList.SelectedItem;
                SetProductInfo(chosenProduct);
            }
            catch { }
            
        }

        public void ClearInfo()
        {
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
            cbCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductInfo();
                _productService.Create(product);
                LoadProduct();
                ClearInfo();
            }
            catch { }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (chosenProduct != null)
            {
                Product product = GetProductInfo();
                product.Id = chosenProduct.Id;
                _productService.Update(product);
                LoadProduct();
                chosenProduct = null;
                ClearInfo();
            } else
            {
                MessageBox.Show("Please choose a product to update!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chosenProduct == null)
                {
                    MessageBox.Show("Please choose a item to delete!");
                    return;
                }
                var result = MessageBox.Show("Are you sure to delete " + chosenProduct.ProductName + "?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool res = _productService.Delete(chosenProduct);
                    LoadProduct();
                    chosenProduct = null;
                    ClearInfo();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            if (string.IsNullOrEmpty(search)) { 
                LoadProduct();
            } else
            {
                var listProduct = _productService.SearchByName(search);
                dtgProductList.ItemsSource = listProduct;
            }
        }
    }
}
