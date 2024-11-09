using System;
using System.Collections.Generic;

namespace Tech_BussinessObjects
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
