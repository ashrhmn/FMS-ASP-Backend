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
            var aircraftName = aircraft.Name;

            var bsfs = new List<object>();
            foreach (var p in aircraft.SeatInfos)
            {
                //var user = (from u in DataAccessFactory.UserDataAccess().GetAll() where u.Id == id select UserModel.FromDb(u)).FirstOrDefault();
                var bsf = new
                {
                    Purchased_By = p.PurchasedTicket.PurchasedByUser.Name
                };
                bsfs.Add(bsf);
            }
            return bsfs;
        }
    }
}
