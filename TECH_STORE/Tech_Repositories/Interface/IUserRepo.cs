using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech_BussinessObjects;

namespace Tech_Repositories.Interface
{
    public interface IUserRepo
    {
        public User FindUserByID(int id);

        public User FindUserByEmail(string email);

        public List<User> GetAllUser();
    }
}
