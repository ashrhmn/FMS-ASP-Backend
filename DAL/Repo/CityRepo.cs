using DAL.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DAL.Repo
{
    public class CityRepo : IRepository<City, int>
    {
        private readonly FmsEntities _db;

        public CityRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(City obj)
        {
            if (obj == null) return false;
            _db.Cities.Add(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Update(int id, City obj)
        {
            var city = _db.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null) return false;
            obj.Id = id;
            _db.Cities.AddOrUpdate(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var city = _db.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null) return false;
            _db.Cities.Remove(city);
            return _db.SaveChanges() != 0;
        }

        public List<City> GetAll()
        {
            return _db.Cities.ToList();
        }

        public City GetById(int id)
        {
            return _db.Cities.FirstOrDefault(c => c.Id == id);
        }
    }
}
