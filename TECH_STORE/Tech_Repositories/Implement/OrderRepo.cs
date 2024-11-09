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
    public class OrderRepo : IOrderRepo
    {
        public int Count() => OrderDao.Instance.Count();

        public List<Order> GetAllOrders() => OrderDao.Instance.GetAllOrders();

        public List<Order> GetOrdersPagination(int page, int pageSize) => OrderDao.Instance.GetOrdersPagination(page, pageSize);
    }
}
