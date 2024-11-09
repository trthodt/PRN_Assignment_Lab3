using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Tech_BussinessObjects;

namespace Tech_Daos.JSON_Dao
{
    public class UserDao
    {
        private readonly string _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Tech_BussinessObjects\JSONData\data.json");
        private DataManagement _data;

        private static UserDao instance = null;

        public static UserDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDao();
                }
                return instance;
            }
        }

        private UserDao()
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

        public User FindUserByID(int id)
        {
            return _data.Users?.FirstOrDefault(m => m.Id == id);
        }

        public User FindUserByEmail(string email)
        {
            return _data.Users?.FirstOrDefault(m => m.Email == email);
        }

        public List<User> GetAllUser()
        {
            return _data.Users ?? new List<User>();
        }

        public void AddUser(User user)
        {
            _data.Users.Add(user);
            SaveData();
        }

        public void DeleteUser(int id)
        {
            var user = _data.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _data.Users.Remove(user);
                SaveData();
            }
        }
    }
}
