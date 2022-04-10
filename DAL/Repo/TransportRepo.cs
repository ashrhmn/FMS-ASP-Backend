using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public class TransportRepo : IRepository<Transport, int>
    {
        private readonly FmsEntities db;

        public TransportRepo(FmsEntities db)
        {
            this.db = db;
        }

        public bool Add(Transport obj)
        {
            if (obj == null) return false;
            db.Transports.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Update(int id, Transport obj)
        {
            var t = db.Transports.FirstOrDefault(s => s.Id == id);
            if (t == null) return false;
            obj.Id = id;
            db.Entry(t).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var t = db.Transports.FirstOrDefault(s => s.Id == id);
            if (t == null) return false;
            db.Transports.Remove(t);
            return db.SaveChanges() != 0;
        }

        public List<Transport> GetAll()
        {
            return db.Transports.ToList();
        }

        public Transport GetById(int id)
        {
            return db.Transports.FirstOrDefault(s => s.Id == id);
        }

    }
}
