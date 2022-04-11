using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class FamilyRepo : IRepository<Family, int>
    {
        private readonly FmsEntities db;

        public FamilyRepo(FmsEntities db)
        {
            this.db = db;
        }

        public bool Add(Family obj)
        {
            if (obj == null) return false;
            db.Families.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var family = db.Families.FirstOrDefault(f => f.Id == id);
            if (family == null) return false;
            db.Families.Remove(family);
            return db.SaveChanges() != 0;
        }

        public List<Family> GetAll()
        {
            return db.Families.ToList();
        }

        public Family GetById(int id)
        {
            return db.Families.FirstOrDefault(f => f.Id == id);
        }

        public bool Update(int id, Family obj)
        {
            var family = db.Families.FirstOrDefault(f => f.Id == id);
            if (family == null) return false;
            obj.Id = id;
            db.Entry(family).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
