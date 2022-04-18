using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repo
{
    internal class UserRoleEnumRepo : IRepository<UserRoleEnum, int>
    {
        private readonly FmsEntities _db;

        public UserRoleEnumRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(UserRoleEnum obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserRoleEnum> GetAll()
        {
            return _db.UserRoleEnums.ToList();
        }

        public UserRoleEnum GetById(int id)
        {
            return _db.UserRoleEnums.FirstOrDefault(r => r.Id == id);
        }

        public bool Update(int id, UserRoleEnum obj)
        {
            throw new NotImplementedException();
        }
    }
}
