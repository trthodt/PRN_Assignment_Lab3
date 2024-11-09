using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Tech_BussinessObjects
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; } = null!;

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
