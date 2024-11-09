using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Repositories.Interface
{
    public interface IProductRepo
    {
        public List<Product> SearchByName(string name);
        public List<Product> GetProducts();

        public Product? GetProduct(int id);

        public bool Delete(Product product);

        public bool Create(Product product);

        public bool Update(Product product);
    }
}
