using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;
using Tech_Daos;
using Tech_Repositories.Interface;

namespace Tech_Repositories.Implement
{
    public class ProductRepo : IProductRepo
    {
        public List<Product> SearchByName(string name) => ProductDao.Instance.SearchByName(name);
        public bool Create(Product product) => ProductDao.Instance.Create(product);

        public bool Delete(Product product) => ProductDao.Instance.Delete(product);

        public Product? GetProduct(int id) => ProductDao.Instance.GetProduct(id);

        public List<Product> GetProducts() => ProductDao.Instance.GetProducts();

        public bool Update(Product product) => ProductDao.Instance.Update(product);
    }
}
