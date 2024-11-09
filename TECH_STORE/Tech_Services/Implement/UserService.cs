using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;
using Tech_Repositories.Implement;
using Tech_Repositories.Interface;
using Tech_Services.Interface;

namespace Tech_Services.Implement
{
    public class UserService : IUserService
    {
        private IUserRepo _userRepo = null;

        public UserService() { 
            if (_userRepo == null)
            {
                _userRepo = new UserRepo();
            }
        }


        public User FindUserByEmail(string email) => _userRepo.FindUserByEmail(email);

        public User FindUserByID(int id) => _userRepo.FindUserByID(id);

        public List<User> GetAllUser() => _userRepo.GetAllUser();
    }
}
