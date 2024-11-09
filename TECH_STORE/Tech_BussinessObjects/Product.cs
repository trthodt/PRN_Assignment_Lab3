using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Tech_BussinessObjects
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("product_name")]
        public string ProductName { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        // Remove virtual keyword for JSON compatibility
        [JsonPropertyName("category")]
        public Category? Category { get; set; }

        [JsonPropertyName("order_details")]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
