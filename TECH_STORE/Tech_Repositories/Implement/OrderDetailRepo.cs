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
    public class OrderDetailRepo : IOrderDetailRepo
    {
        public List<OrderDetail> GetOrderDetailByOrderId(int orderId) => OrderDetailDao.Instance.GetOrderDetailByOrderId(orderId);
    }
}
