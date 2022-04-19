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
            var si = DataAccessFactory.SeatInfoDataAccess().GetAll().Where(u => u.TransportId == id).Select(seatinfo => SeatInfoModel.FromDb(seatinfo, true)).ToList();
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
                    Aircraft_Id = aircraftId,
                    Aircrafts_name = aircraftName,
                    Seat_No = s.SeatNo,
                    Seat_quality = s.SeatClassEnum.Value,
                    From_stopage = fromstopage.Name+", "+fromstopage.City.Name,
                    To_stopage = tostopage.Name+", "+tostopage.City.Name,
                    Purchased_By = s.PurchasedTicket.PurchasedByUser
                };
                bsfs.Add(bsf);
            }
            
            
            return bsfs;
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
