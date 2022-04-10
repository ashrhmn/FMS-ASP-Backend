using DAL.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DAL.Repo
{
    public class TicketRepo : IRepository<PurchasedTicket, int>
    {
        private readonly FmsEntities _db;

        public TicketRepo(FmsEntities db)
        {
            _db = db;
        }
        public bool Add(PurchasedTicket obj)
        {
            if (obj == null) return false;
            _db.PurchasedTickets.Add(obj);
            return _db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var ticket = _db.PurchasedTickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return false;
            _db.PurchasedTickets.Remove(ticket);
            return _db.SaveChanges() != 0;
        }

        public List<PurchasedTicket> GetAll()
        {
            return _db.PurchasedTickets.ToList();
        }

        public PurchasedTicket GetById(int id)
        {
            return _db.PurchasedTickets.FirstOrDefault(t => t.Id == id);
        }
        
        public bool Update(int id, PurchasedTicket obj)
        {
            var ticket = _db.PurchasedTickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return false;
            obj.Id = id;
            _db.PurchasedTickets.AddOrUpdate(obj);
            return _db.SaveChanges() != 0;
        }
    }
}
