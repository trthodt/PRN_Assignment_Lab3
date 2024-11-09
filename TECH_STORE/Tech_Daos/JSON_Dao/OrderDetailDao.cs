using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Tech_BussinessObjects;

namespace Tech_Daos.JSON_Dao
{
    public class OrderDetailDao
    {
        private readonly string _jsonOrderDetailsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Tech_BussinessObjects\JSONData\data.json");
        private DataManagement _data; 

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
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_jsonOrderDetailsFilePath))
            {
                string jsonData = File.ReadAllText(_jsonOrderDetailsFilePath);
                _data = System.Text.Json.JsonSerializer.Deserialize<DataManagement>(jsonData) ?? new DataManagement();
            }
            else
            {
                _data = new DataManagement();
            }
        }

        // Phương thức lưu dữ liệu vào file JSON
        private void SaveData()
        {
            string jsonData = System.Text.Json.JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonOrderDetailsFilePath, jsonData);
        }

        // Phương thức lấy chi tiết đơn hàng theo OrderId, bao gồm thông tin sản phẩm
        public List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            var orderDetails = _data.OrderDetails?.Where(x => x.OrderId == orderId).ToList() ?? new List<OrderDetail>();

            // Gán sản phẩm cho từng chi tiết đơn hàng
            foreach (var orderDetail in orderDetails)
            {
                orderDetail.Product = _data.Products?.FirstOrDefault(p => p.Id == orderDetail.ProductId);
            }

            return orderDetails;
        }
    }
}
