using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Tech_BussinessObjects;

namespace Tech_Daos.JSON_Dao
{
    public class OrderDao
    {
        private readonly string _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Tech_BussinessObjects\JSONData\data.json");
        private DataManagement _data; 

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
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_jsonFilePath))
            {
                string jsonData = File.ReadAllText(_jsonFilePath);
                _data = System.Text.Json.JsonSerializer.Deserialize<DataManagement>(jsonData) ?? new DataManagement();
            }
            else
            {
                _data = new DataManagement();
            }
        }

        private void SaveData()
        {
            string jsonData = System.Text.Json.JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, jsonData);
        }

        public List<Order> GetAllOrders()
        {
            return _data.Orders ?? new List<Order>();
        }

        public int Count()
        {
            return _data.Orders?.Count ?? 0;
        }

        public List<Order> GetOrdersPagination(int page, int pageSize)
        {
            var orders = _data.Orders?
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList() ?? new List<Order>();

            foreach (var order in orders)
            {
                order.User = _data.Users?.FirstOrDefault(u => u.Id == order.UserId);
            }

            return orders;
        }
    }
}
