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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo = null;

        public OrderService()
        {
            _orderRepo = new OrderRepo();
        }

        public int Count() => _orderRepo.Count();

        public List<Order> GetAllOrders() => _orderRepo.GetAllOrders();

        public List<Order> GetOrdersPagination(int page, int pageSize) => _orderRepo.GetOrdersPagination(page, pageSize);
    }
}
