using System;
using System.Collections.Generic;

namespace Tech_BussinessObjects
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
