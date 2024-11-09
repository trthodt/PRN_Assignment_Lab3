using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Tech_BussinessObjects;

namespace Tech_Daos.JSON_Dao
{
    public class ProductDao
    {
        private readonly string _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Tech_BussinessObjects\JSONData\data.json");
        private DataManagement _data; 

        private static ProductDao instance = null;

        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDao();
                }
                return instance;
            }
        }

        private ProductDao()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_jsonFilePath))
            {
                string jsonData = File.ReadAllText(_jsonFilePath);
                _data = System.Text.Json.JsonSerializer.Deserialize<DataManagement>(jsonData) ?? new DataManagement();
            }
            else
            {
                _data = new DataManagement();
            }
        }

        private void SaveData()
        {
            string jsonData = System.Text.Json.JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, jsonData);
        }

        public Product? GetProduct(int id)
        {
            var product = _data.Products?.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Category = _data.Categories?.FirstOrDefault(c => c.Id == product.CategoryId);
            }
            return product;
        }

        public List<Product> SearchByName(string name)
        {
            var products = _data.Products?.Where(x => x.ProductName.ToLower().Contains(name.ToLower())).ToList() ?? new List<Product>();

            // Add categories for each product
            foreach (var product in products)
            {
                product.Category = _data.Categories?.FirstOrDefault(c => c.Id == product.CategoryId);
            }

            return products;
        }

        public List<Product> GetProducts()
        {
            if (_data.Products != null)
            {
                foreach (var product in _data.Products)
                {
                    product.Category = _data.Categories?.FirstOrDefault(c => c.Id == product.CategoryId);
                }
            }

            return _data.Products ?? new List<Product>();
        }

        public bool Create(Product product)
        {
            try
            {
                int newId = _data.Products.Any() ? _data.Products.Max(x => x.Id) + 1 : 1;

                product.Id = newId;

                _data.Products.Add(product);
                SaveData();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Product product)
        {
            try
            {
                var productToDelete = _data.Products?.FirstOrDefault(x => x.Id == product.Id);
                if (productToDelete != null)
                {
                    _data.Products.Remove(productToDelete);
                    SaveData();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                var productToUpdate = _data.Products?.FirstOrDefault(x => x.Id == product.Id);
                if (productToUpdate != null)
                {
                    productToUpdate.Price = product.Price;
                    productToUpdate.Description = product.Description;
                    productToUpdate.CategoryId = product.CategoryId;
                    productToUpdate.ProductName = product.ProductName;
                    productToUpdate.Quantity = product.Quantity;
                    SaveData();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
