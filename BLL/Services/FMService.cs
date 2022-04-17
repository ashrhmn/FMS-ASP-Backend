using BLL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FMService
    {
        public static UserModel Profile(int id)
        {
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);   
            return data;
        }

        public static bool UpdateProfile(int id, UserModel userModel, string cPass)
        {
            var udata = UserService.GetUser(id);
            bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(cPass, udata.Password);
            if (isCorrectPassword)
            {
                UserModel nwUser = new UserModel();
                nwUser.Id = userModel.Id;
                nwUser.Name = userModel.Name;
                nwUser.DateOfBirth = userModel.DateOfBirth;
                nwUser.Address = userModel.Address;
                nwUser.CityId = userModel.CityId;
                nwUser.Username = userModel.Username;
                nwUser.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password, 12);
                nwUser.Email = userModel.Email;
                nwUser.Phone = userModel.Phone;
                nwUser.Role = 3;
                return DataAccessFactory.UserDataAccess().Update(id, nwUser.GetDbModel());
            }
            return false;
        }
    }
}
