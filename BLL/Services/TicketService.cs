﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static bool UpdateTicket(PurchasedTicketModel ticketModel)
        {
            return DataAccessFactory.TicketDataAccess().Update(ticketModel.GetDbModel());
        }

        public static bool DeleteTicket(int id)
        {
            return DataAccessFactory.TicketDataAccess().Delete(id);
        }
    }
}
