using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Daos
{
    public class OrderDetailDao
    {
        private PRN221_ASSIGNMENTContext _context;

        private static OrderDetailDao instance = null;

        public static OrderDetailDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDao();
                }
                return instance;
            }
        }

        private OrderDetailDao()
        {
            _context = new PRN221_ASSIGNMENTContext();
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderId) => _context.OrderDetails.Include(x=> x.Product).Where(x => x.OrderId == orderId).ToList();
    }
}
