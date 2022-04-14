using BLL.Entities;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ManagerService
    {
        public static UserModel GetUser(int id)
        {
            return UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);
        }
        public static bool UpdateProfile(int id, UserModel userModel)
        {
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);
            userModel.Username = data.Username;
            userModel.Password = data.Password;
            userModel.FamilyId = data.FamilyId;
            userModel.CityId = data.CityId;
            userModel.Role = data.Role;
            return DataAccessFactory.UserDataAccess().Update(id, userModel.GetDbModel());
        }
        public static string ChangePass(int id, string OldPassword, string Password, string ConPassword)
        {
            if (Password.Equals(ConPassword))
            {
                var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);

                bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(OldPassword, data.Password);

                if (isCorrectPassword)
                {
                    var user = new UserModel()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Username = data.Username,
                        Password = BCrypt.Net.BCrypt.HashPassword(Password, 12),  // this Bcrypt
                        Address = data.Address,
                        DateOfBirth = data.DateOfBirth,
                        CityId = data.CityId,
                        FamilyId = data.FamilyId,
                        Role = data.Role,
                        Email = data.Email,
                        Phone = data.Phone
                    };
                    DataAccessFactory.UserDataAccess().Update(id, user.GetDbModel());

                    return "Password Changed Successfully";
                }
                return "Old Password is not correct";

            }
            return "Password & Confirm Password Not Matched";
        }

        //public static bool UserlistSearch(string Uname, string Purchase)
        //{
        //    List<User> data;
        //    if (Uname == "" && Purchase != "true")
        //    {
        //        //data = (from u in db.Users where u.Role == 2 select u).ToList();
        //        data = DataAccessFactory.UserDataAccess().GetAll().Where(u => u.Role == 2).ToList();
        //    }
        //    else if (Uname != "" && Purchase != "true")
        //    {
        //        data = (from u in db.Users where u.Role == 2 && u.Username.Contains(Uname) select u).ToList();

        //    }
        //    else if (Uname == "" && Purchase == "true")
        //    {
        //        data = db.PurchasedTickets.Select(pb => pb.User).ToList();
        //    }
        //    else if (Uname != "" && Purchase == "true")
        //    {
        //        data = db.PurchasedTickets.Select(pb => pb.User).Where(pw => pw.Username.Contains(Uname)).ToList();
        //    }
        //    else
        //    {
        //        data = null;
        //    }
        //    if (data != null)
        //    {
        //        var users = new List<UserModel>();
        //        foreach (var disUser in data)
        //        {
        //            if (!users.Select(u => u.Id).ToList().Contains(disUser.Id))
        //            {
        //                users.Add(new UserModel()
        //                {
        //                    Name = disUser.Name,
        //                    Username = disUser.Username,
        //                    Id = disUser.Id,
        //                    PurchasedTickets = disUser.PurchasedTickets.Select(e => e.Id).ToList(),
        //                });
        //            }
        //        }
        //        return View(users);
        //    }
        //    return null;
        //}



    }
}
