﻿using System;
using DAL.Database;

namespace BLL.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? FamilyId { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Role { get; set; }
        public FamilyModel Family { get; set; }
        public CityModel City { get; set; }
        public string RoleEnum { get; set; }

        public static UserModel FromDb(User user, bool extended = false)
        {
            if (user == null) return null;
            var model = new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                FamilyId = user.FamilyId,
                Address = user.Address,
                CityId = user.CityId,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
            };
            if (!extended) return model;
            model.Family = FamilyModel.FromDb(user.Family);
            model.City = CityModel.FromDb(user.City);
            model.RoleEnum = user.UserRoleEnum.Value;
            return model;
        }
        public User GetDbModel()
        {
            return new User() { Address = Address,CityId = CityId,DateOfBirth = DateOfBirth,Email = Email,FamilyId = FamilyId,Id = Id,Password = Password,Phone = Phone,Role = Role,Username = Username,Name = Name};
        }

    }

 
}
