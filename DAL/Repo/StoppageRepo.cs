using DAL.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DAL.Repo
{
    public class StoppageRepo : IRepository<Stoppage, int>
    {
        private readonly FmsEntities _db;

        public StoppageRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(Stoppage obj)
        {
            if (obj == null) return false;
            _db.Stoppages.Add(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Update(int id, Stoppage obj)
        {
            var stoppage = _db.Stoppages.FirstOrDefault(s => s.Id == id);
            if (stoppage == null) return false;
            obj.Id = id;
            _db.Stoppages.AddOrUpdate(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var stoppage = _db.Cities.FirstOrDefault(s => s.Id == id);
            if (stoppage == null) return false;
            _db.Cities.Remove(stoppage);
            return _db.SaveChanges() != 0;
        }

        public List<Stoppage> GetAll()
        {
            return _db.Stoppages.ToList();
        }

        public Stoppage GetById(int id)
        {
            return _db.Stoppages.FirstOrDefault(s => s.Id == id);
        }
    }
}
