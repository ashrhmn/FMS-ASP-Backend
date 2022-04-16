using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SeatClassEnumRepo : IRepository<SeatClassEnum, int>
    {
        private readonly FmsEntities _db;

        public SeatClassEnumRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(SeatClassEnum obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SeatClassEnum> GetAll()
        {
            return _db.SeatClassEnums.ToList();
        }

        public SeatClassEnum GetById(int id)
        {
            return _db.SeatClassEnums.FirstOrDefault(r => r.Id == id);
        }

        public bool Update(int id, SeatClassEnum obj)
        {
            throw new NotImplementedException();
        }
    }
}
