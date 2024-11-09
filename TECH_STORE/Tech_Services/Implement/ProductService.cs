using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;
using Tech_Repositories.Implement;
using Tech_Repositories.Interface;
using Tech_Services.Interface;

namespace Tech_Services.Implement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo = null;

        public ProductService()
        {
            if (_productRepo == null)
            {
                _productRepo = new ProductRepo();
            }
        }

        public List<Product> SearchByName(string name) => _productRepo.SearchByName(name);

        public bool Create(Product product) => _productRepo.Create(product);

        public bool Delete(Product product) => _productRepo.Delete(product);

        public Product? GetProduct(int id) => _productRepo?.GetProduct(id);

        public List<Product> GetProducts() => _productRepo.GetProducts();

        public bool Update(Product product) => _productRepo.Update(product);
    }
}
