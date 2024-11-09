using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Daos
{
    public class ProductDao
    {
        private PRN221_ASSIGNMENTContext _context;
        private static ProductDao instance;
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
            _context = new PRN221_ASSIGNMENTContext();
        }

        public List<Product> SearchByName(string name) => _context.Products.Include(x => x.Category).Where(x => x.ProductName.ToLower().Contains(name.ToLower())).ToList();

        public List<Product> GetProducts() => _context.Products.Include(x => x.Category).ToList();

        public Product? GetProduct(int id) => _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

        public bool Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product product) {
            try
            {
                Product? productToUpdate = GetProduct(product.Id);
                if (productToUpdate == null)
                {
                    return false;
                }
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Quantity = product.Quantity;
                _context.Products.Update(productToUpdate);
                var result = _context.SaveChanges();
                return result > 0;

            }
            catch
            {
                return false;
            }
        }
    }
}
