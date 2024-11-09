using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Services.Interface
{
    public interface IOrderService
    {
        public List<Order> GetAllOrders();

        public int Count();

        public List<Order> GetOrdersPagination(int page, int pageSize);
    }
}
