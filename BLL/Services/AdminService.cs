using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class AdminService
    {
        public static List<UserModel> GetAllAdmin()
        {
            return DataAccessFactory.UserDataAccess().GetAll().Where(u => u.Role == 1).Select(user => UserModel.FromDb(user, true)).ToList();
        }
        public static List<UserModel> GetAllManager()
        {
            return DataAccessFactory.UserDataAccess().GetAll().Where(u => u.Role == 4).Select(user => UserModel.FromDb(user, true)).ToList();
        }
        public static List<UserModel> GetAllCustomer()
        {
            return DataAccessFactory.UserDataAccess().GetAll().Where(u => u.Role == 2).Select(user => UserModel.FromDb(user, true)).ToList();
        }
        public static List<UserModel> GetAllFlightManager()
        {
            return DataAccessFactory.UserDataAccess().GetAll().Where(u => u.Role == 3).Select(user => UserModel.FromDb(user, true)).ToList();
        }
        public static object BookedSeatsForFlight(int id)
        {
            var aircraft = TransportModel.FromDb(DataAccessFactory.TransportDataAccess().GetById(id), true);
            var si = DataAccessFactory.SeatInfoDataAccess().GetAll().Where(u => u.TransportId == id).Where(u => u.Status == "Booked").Select(seatinfo => SeatInfoModel.FromDb(seatinfo, true)).ToList();
            var aircraftName = aircraft.Name;
            var aircraftId = aircraft.Id;
            //return aircraft.SeatInfos.ToList();

            //var users = aircraft.SeatInfos.Select(si => si.PurchasedTicket).ToList();

            //return users;

            var bsfs = new List<object>();
            foreach (var s in si)
            {
                var fromstopage = StoppageModel.FromDb(DataAccessFactory.StoppageDataAccess().GetById(s.PurchasedTicket.FromStoppageId), true);
                var tostopage = StoppageModel.FromDb(DataAccessFactory.StoppageDataAccess().GetById(s.PurchasedTicket.ToStoppageId), true);
                
                var bsf = new
                {
                    Seat_No = s.SeatNo,
                    Seat_quality = s.SeatClassEnum.Value,
                    From_stopage = fromstopage.Name+", "+fromstopage.City.Name,
                    To_stopage = tostopage.Name+", "+tostopage.City.Name,
                    Status = s.Status,
                    Purchased_By = s.PurchasedTicket.PurchasedByUser,
                    
                };
                bsfs.Add(bsf);
            }
            var Aircraft = new
            {
                Aircraft_Id = aircraftId,
                Aircrafts_name = aircraftName,
                Booked_Seats =bsfs
            };


            return Aircraft;
        }
        public static object PurchasedTicketsForUser(int id)
        {
            var user = (from u in DataAccessFactory.UserDataAccess().GetAll() where u.Id == id select UserModel.FromDb(u,true)).FirstOrDefault();
            var purchasedTic = (from pt in DataAccessFactory.TicketDataAccess().GetAll() where pt.PurchasedBy == id select PurchasedTicketModel.FromDb(pt,true)).ToList();
            var ticketDetails = new List<object>();
            foreach (var prt in purchasedTic)
            {
                var seatinfo = (from s in DataAccessFactory.SeatInfoDataAccess().GetAll() where s.TicketId == prt.Id select SeatInfoModel.FromDb(s, true)).FirstOrDefault();
                //return seatinfo;
                var ticketDetail = new
                {
                    Ticket_Id = prt.Id,
                    Aircraft_Name = seatinfo == null ? "Undefined" : seatinfo.Transport.Name,
                    From = prt.FromStoppage.Name,
                    To = prt.ToStoppage.Name,
                    Time = seatinfo == null ? null : seatinfo.StartTime,
                    Seat_no = seatinfo == null ? 0 : seatinfo.SeatNo,
                    Age = seatinfo == null ? "Undefined" : seatinfo.AgeClassEnum.Value,
                    Seat_Class = seatinfo == null ? "Undefined" : seatinfo.SeatClassEnum.Value,
                    
                };
                ticketDetails.Add(ticketDetail);
            }
            var Customer = new
            {
                Customer_Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                TicketDetails = ticketDetails.ToList()
            };
            return Customer;  
        }

        public static object SearchFlight(string Name)
        {
            var data = (from t in DataAccessFactory.TransportDataAccess().GetAll() where t.Name.ToLower().Contains(Name.ToLower()) select TransportModel.FromDb(t, true)).ToList();
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public static object SearchUser(string Name)
        {
            var data = (from u in DataAccessFactory.UserDataAccess().GetAll() where u.Name.ToLower().Contains(Name.ToLower()) select UserModel.FromDb(u, true)).ToList();
            if (data != null)
            {
                return data;
            }
            return null;
        }

    }
}
