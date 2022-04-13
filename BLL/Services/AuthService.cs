using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class AuthService
    {
        public static UserModel Authenticate(string username, string password)
        {
            var user =DataAccessFactory.UserDataAccess().GetAll().FirstOrDefault(u => u.Username == username);
            return UserModel.FromDb(user,true);
        }
    }
}
