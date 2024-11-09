using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;
using Tech_Daos;
using Tech_Repositories.Interface;

namespace Tech_Repositories.Implement
{
    public class UserRepo : IUserRepo
    {
        public User FindUserByEmail(string email) => UserDao.Instance.FindUserByEmail(email);

        public User FindUserByID(int id) => UserDao.Instance.FindUserByID(id);

        public List<User> GetAllUser() => UserDao.Instance.GetAllUser();
    }
}
