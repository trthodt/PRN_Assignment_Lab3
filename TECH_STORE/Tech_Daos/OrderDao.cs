using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Daos
{
    public class OrderDao
    {
        private PRN221_ASSIGNMENTContext _context;

        private static OrderDao instance = null;

        public static OrderDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDao();
                }
                return instance;
            }
        }

        private OrderDao()
        {
            _context = new PRN221_ASSIGNMENTContext();
        }
        
        public List<Order> GetAllOrders() => _context.Orders.Include(x => x.OrderDetails).Include(x => x.User).ToList();

        public int Count() => _context.Orders.Count();

        public List<Order> GetOrdersPagination(int page, int pageSize)
        {
            var orders = _context.Orders
                .Include(x => x.OrderDetails)
                .Include(x => x.User)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return orders;
        }

    }
}
