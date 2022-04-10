using BLL.Entities;
using DAL;
using System.Collections.Generic;

namespace BLL.Services
{
    internal class SeatInfoService
    {
        public static List<SeatInfoModel> GetAllTicket()
        {
            //return DataAccessFactory.SeatInfoDataAccess().GetAll().Select(city => PurchasedTicketModel.FromDb(city, true)).ToList();
            return null;
        }

        public static PurchasedTicketModel GetTicket(int id)
        {
            return PurchasedTicketModel.FromDb(DataAccessFactory.TicketDataAccess().GetById(id), true);
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
