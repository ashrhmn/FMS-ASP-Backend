using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class TransportScheduleService
    {
        public static List<TransportScheduleModel> GetAllTransportSchedule()
        {

            return DataAccessFactory.TransportScheduleDataAccess().GetAll().Select(transports => TransportScheduleModel.FromDb(transports, true)).ToList();
        }

        public static TransportScheduleModel GetTransportSchedule(int id)
        {
            return TransportScheduleModel.FromDb(DataAccessFactory.TransportScheduleDataAccess().GetById(id), true);
        }

        public static bool AddTransportSchedule(TransportScheduleModel transportScheduleModel)
        {
            return DataAccessFactory.TransportScheduleDataAccess().Add(transportScheduleModel.GetDbModel());
        }

        public static bool UpdateTransportSchedule(int id,TransportScheduleModel transportScheduleModel)
        {
            return DataAccessFactory.TransportScheduleDataAccess().Update(id,transportScheduleModel.GetDbModel());
        }

        public static bool DeleteTransportSchedule(int id)
        {
            return DataAccessFactory.TransportScheduleDataAccess().Delete(id);
        }
    }
}
