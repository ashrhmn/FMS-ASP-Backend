using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserModel> GetAllUsers()
        {

            return DataAccessFactory.UserDataAccess().GetAll().Select(user => UserModel.FromDb(user, true)).ToList();
        }

        public static UserModel GetUser(int id)
        {
            return UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), true);
        }

        public static bool AddUser(UserModel userModel)
        {
            return DataAccessFactory.UserDataAccess().Add(userModel.GetDbModel());
        }

        public static bool UpdateUser(UserModel userModel)
        {
            return DataAccessFactory.UserDataAccess().Update(userModel.GetDbModel());
        }

        public static bool DeleteUser(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }
    }
}
