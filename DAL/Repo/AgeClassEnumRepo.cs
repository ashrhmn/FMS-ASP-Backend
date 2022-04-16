using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AgeClassEnumRepo : IRepository<AgeClassEnum, int>
    {
        private readonly FmsEntities _db;

        public AgeClassEnumRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(AgeClassEnum obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AgeClassEnum> GetAll()
        {
            return _db.AgeClassEnums.ToList();
        }

        public AgeClassEnum GetById(int id)
        {
            return _db.AgeClassEnums.FirstOrDefault(r => r.Id == id);
        }

        public bool Update(int id, AgeClassEnum obj)
        {
            throw new NotImplementedException();
        }
    }
}
