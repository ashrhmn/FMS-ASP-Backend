using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TicketRepoNew : IRepositoryNew<PurchasedTicket, int>
    {
        private readonly FmsEntities _db;

        public TicketRepoNew(FmsEntities db)
        {
            _db = db;
        }
        public PurchasedTicket Add(PurchasedTicket obj)
        {
            if (obj == null) return null;
            _db.PurchasedTickets.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchasedTicket> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchasedTicket GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, PurchasedTicket obj)
        {
            throw new NotImplementedException();
        }
    }
}
