using BLL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class FMService
    {
        public static UserModel Profile(int id)
        {
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);   
            return data;
        }

        public static bool UpdateProfile(int id, UserModel userModel, string cPass)
        {
            var udata = UserService.GetUser(id);
            bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(cPass, udata.Password);
            if (isCorrectPassword)
            {
                UserModel nwUser = new UserModel();
                nwUser.Id = userModel.Id;
                nwUser.Name = userModel.Name;
                nwUser.DateOfBirth = userModel.DateOfBirth;
                nwUser.Address = userModel.Address;
                nwUser.CityId = userModel.CityId;
                nwUser.Username = userModel.Username;
                nwUser.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password, 12);
                nwUser.Email = userModel.Email;
                nwUser.Phone = userModel.Phone;
                nwUser.Role = 3;
                return DataAccessFactory.UserDataAccess().Update(id, nwUser.GetDbModel());
            }
            return false;
        }

        public static List<TransportModel> GetAllTransport(int cid)
        {

            return DataAccessFactory.UTransportDataAccess().GetAll(cid).Select(transport => TransportModel.FromDb(transport, true)).ToList();
        }

        public static List<BookedTicketModel> GetTickets(int id, bool booked)
        {
            string key;
            if (booked) { key = "Booked"; }
            else { key = "Pending Cancelation"; }
            var trans = (from t in DataAccessFactory.TransportDataAccess().GetAll() where t.CreatedBy == id select t).ToList();
            var BookedTkts = new List<BookedTicketModel>();

            foreach (var t in trans)
            { 
                var sinfo = (from si in DataAccessFactory.SeatInfoDataAccess().GetAll() where (si.TransportId == t.Id && si.Status.Equals(key)) select si).ToList();
                foreach (var si in sinfo)
                {
                    var FromRootFare = si.PurchasedTicket.Stoppage.FareFromRoot;
                    var ToRootFare = si.PurchasedTicket.Stoppage1.FareFromRoot; ;
                    var baseFare = Math.Abs((FromRootFare ?? -1) - (ToRootFare ?? -1));
                    var fare = 0;
                    if (si.SeatClass == 1)
                    {
                        fare = baseFare * 15;

                    }
                    else if (si.SeatClass == 2)
                    {
                        fare = baseFare * 10;
                    }
                    else
                    {
                        fare = baseFare * 12;
                    }
                    BookedTkts.Add(new BookedTicketModel()
                    {
                        Id = si.TicketId,
                        SeatNo = si.SeatNo,
                        StartTime = si.StartTime,
                        SeatClass = si.SeatClassEnum.Value,
                        FromStoppage = si.PurchasedTicket.Stoppage.Name,
                        ToStoppageId = si.PurchasedTicket.Stoppage1.Name,
                        TransportName = si.Transport.Name,
                        Status = si.Status,
                        PurchasedBy = new UserModel() {Id = si.PurchasedTicket.User.Id, Name = si.PurchasedTicket.User.Name,
                           Address = si.PurchasedTicket.User.Address, Email = si.PurchasedTicket.User.Email, Phone = si.PurchasedTicket.User.Phone
                        },
                        Fare = fare
                        
                    }) ; 
                }
            }

            return BookedTkts;
        }

        public static BookedTicketModel GetTicket(int id)
        {
                var sinfo = (from si in DataAccessFactory.SeatInfoDataAccess().GetAll() where (si.TicketId == id && si.Status.Equals("Booked")) select si).FirstOrDefault();
                    var FromRootFare = sinfo.PurchasedTicket.Stoppage.FareFromRoot;
                    var ToRootFare = sinfo.PurchasedTicket.Stoppage1.FareFromRoot; ;
                    var baseFare = Math.Abs((FromRootFare ?? -1) - (ToRootFare ?? -1));
                    var fare = 0;
                    if (sinfo.SeatClass == 1)
                    {
                        fare = baseFare * 15;

                    }
                    else if (sinfo.SeatClass == 2)
                    {
                        fare = baseFare * 10;
                    }
                    else
                    {
                        fare = baseFare * 12;
                    }
                    var BookedTkt = new BookedTicketModel()
                    {
                        Id = sinfo.TicketId,
                        SeatNo = sinfo.SeatNo,
                        StartTime = sinfo.StartTime,
                        SeatClass = sinfo.SeatClassEnum.Value,
                        FromStoppage = sinfo.PurchasedTicket.Stoppage.Name,
                        ToStoppageId = sinfo.PurchasedTicket.Stoppage1.Name,
                        TransportName = sinfo.Transport.Name,
                        Status = sinfo.Status,
                        PurchasedBy = new UserModel()
                        {
                            Id = sinfo.PurchasedTicket.User.Id,
                            Name = sinfo.PurchasedTicket.User.Name,
                            Address = sinfo.PurchasedTicket.User.Address,
                            Email = sinfo.PurchasedTicket.User.Email,
                            Phone = sinfo.PurchasedTicket.User.Phone
                        },
                        Fare = fare

                    };

            return BookedTkt;
        }

        public static bool UpdateTicket(int id, SeatInfoModel sim)
        {
            var sdata = (from si in DataAccessFactory.SeatInfoDataAccess().GetAll() where si.TicketId == id select si).FirstOrDefault();
            return DataAccessFactory.SeatInfoDataAccess().Update(id, sim.GetDbModel());
        }

        public static bool DeleteTicket(int id)
        {
            var sdata = (from si in DataAccessFactory.SeatInfoDataAccess().GetAll() where si.TicketId == id select si).FirstOrDefault();
            DataAccessFactory.SeatInfoDataAccess().Delete(sdata.Id);
           return DataAccessFactory.TicketDataAccess().Delete(id);
        }
    }
}
