using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Daos
{
    public class UserDao
    {
        private PRN221_ASSIGNMENTContext _context;

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
            _context = new PRN221_ASSIGNMENTContext();
        }

        public User FindUserByID(int id) => _context.Users.FirstOrDefault(m => m.Id == id);

        public User FindUserByEmail(string email) => _context.Users.FirstOrDefault(m => m.Email == email);

        public List<User> GetAllUser() => _context.Users.ToList();
    }
}
