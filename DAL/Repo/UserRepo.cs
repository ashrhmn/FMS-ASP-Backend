using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Database;

namespace DAL.Repo
{
    public class UserRepo : IRepository<User, int>
    {
        private readonly FmsEntities _db;

        public UserRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(User obj)
        {
            if (obj == null) return false;
            _db.Users.Add(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            _db.Users.Remove(user);
            return _db.SaveChanges() != 0;
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public bool Update(int id, User obj)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            obj.Id = id;
            _db.Users.AddOrUpdate(obj);
            return _db.SaveChanges() != 0;
        }
    }
}
