using System;
using System.Collections.Generic;

namespace Tech_BussinessObjects
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
