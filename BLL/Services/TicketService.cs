using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class TicketService
    {
        public static List<PurchasedTicketModel> GetAllTicket()
        {

            return DataAccessFactory.TicketDataAccess().GetAll().Select(city => PurchasedTicketModel.FromDb(city,true)).ToList();
        }

        public static PurchasedTicketModel GetTicket(int id)
        {
            return PurchasedTicketModel.FromDb(DataAccessFactory.TicketDataAccess().GetById(id),true);
        }

        public static bool AddTicket(PurchasedTicketModel ticketModel)
        {
            return DataAccessFactory.TicketDataAccess().Add(ticketModel.GetDbModel());
        }

        public static bool UpdateTicket(int id,PurchasedTicketModel ticketModel)
        {
            return DataAccessFactory.TicketDataAccess().Update(id,ticketModel.GetDbModel());
        }

        public static bool DeleteTicket(int id)
        {
            return DataAccessFactory.TicketDataAccess().Delete(id);
        }
    }
}
