using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    internal class EmailVerifyTokenRepo : IRepository<EmailVerifyToken, int>
    {
        private readonly FmsEntities _db;
        public EmailVerifyTokenRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(EmailVerifyToken obj)
        {
            obj.CreatedOn = DateTime.Now;
            _db.EmailVerifyTokens.Add(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var data = GetById(id);
            if (data == null) return false;
            _db.EmailVerifyTokens.Remove(data);
            return _db.SaveChanges() != 0;
        }

        public List<EmailVerifyToken> GetAll()
        {
            return _db.EmailVerifyTokens.ToList();
        }

        public EmailVerifyToken GetById(int id)
        {
            return _db.EmailVerifyTokens.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(int id, EmailVerifyToken obj)
        {
            var data = GetById(id);
            if (data == null) return false;
            obj.Id = id;
            _db.EmailVerifyTokens.AddOrUpdate(obj);
            return _db.SaveChanges() != 0;
        }
    }
}
