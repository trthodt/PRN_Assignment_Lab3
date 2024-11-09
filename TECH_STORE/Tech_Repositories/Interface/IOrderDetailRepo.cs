using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Repositories.Interface
{
    public interface IOrderDetailRepo
    {
        public List<OrderDetail> GetOrderDetailByOrderId(int orderId);
    }
}
