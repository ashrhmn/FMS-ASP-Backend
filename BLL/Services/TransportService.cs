using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class TransportService
    {
        public static List<TransportModel> GetAllTransport()
        {

            return DataAccessFactory.TransportDataAccess().GetAll().Select(transport => TransportModel.FromDb(transport, true)).ToList();
        }

        public static TransportModel GetTransport(int id)
        {
            return TransportModel.FromDb(DataAccessFactory.TransportDataAccess().GetById(id), true);
        }

        public static bool AddTransport(TransportModel transportModel)
        {
            return DataAccessFactory.TransportDataAccess().Add(transportModel.GetDbModel());
        }

        public static bool UpdateTransport(int id,TransportModel transportModel)
        {
            return DataAccessFactory.TransportDataAccess().Update(id,transportModel.GetDbModel());
        }

        public static bool DeleteTransport(int id)
        {
            return DataAccessFactory.TransportDataAccess().Delete(id);
        }
    }
}
