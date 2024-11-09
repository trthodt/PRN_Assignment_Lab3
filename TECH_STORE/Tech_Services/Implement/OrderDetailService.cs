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
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepo _orderDetailRepo = null;
        public OrderDetailService() { 
            if (_orderDetailRepo == null)
            {
                _orderDetailRepo = new OrderDetailRepo();
            }
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderId) => _orderDetailRepo.GetOrderDetailByOrderId(orderId);
    }
}
