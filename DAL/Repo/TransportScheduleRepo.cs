using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public class TransportScheduleRepo : IRepository<TransportSchedule, int>
    {
        private readonly FmsEntities db;

        public TransportScheduleRepo(FmsEntities db)
        {
            this.db = db;
        }
        public bool Add(TransportSchedule obj)
        {
            if (obj == null) return false;
            db.TransportSchedules.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Update(int id, TransportSchedule obj)
        {
            var t = db.TransportSchedules.FirstOrDefault(s => s.Id == id);
            if (t == null) return false;
            obj.Id = id;
            db.Entry(t).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var t = db.TransportSchedules.FirstOrDefault(s => s.Id == id);
            if (t == null) return false;
            db.TransportSchedules.Remove(t);
            return db.SaveChanges() != 0;
        }

        public List<TransportSchedule> GetAll()
        {
            return db.TransportSchedules.ToList();
        }

        public TransportSchedule GetById(int id)
        {
            return db.TransportSchedules.FirstOrDefault(s => s.Id == id);
        }
    }
}
