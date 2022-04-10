using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class StoppageService
    {
        public static List<StoppageModel> GetAllStoppage()
        {

            return DataAccessFactory.StoppageDataAccess().GetAll().Select(stoppage => StoppageModel.FromDb(stoppage,true)).ToList();
        }

        public static StoppageModel GetStoppage(int id)
        {
            return StoppageModel.FromDb(DataAccessFactory.StoppageDataAccess().GetById(id),true);
        }

        public static bool AddStoppage(StoppageModel stoppageModel)
        {
            return DataAccessFactory.StoppageDataAccess().Add(stoppageModel.GetDbModel());
        }

        public static bool UpdateStoppage(int id,StoppageModel stoppageModel)
        {
            return DataAccessFactory.StoppageDataAccess().Update(id,stoppageModel.GetDbModel());
        }

        public static bool DeleteStoppage(int id)
        {
            return DataAccessFactory.StoppageDataAccess().Delete(id);
        }
    }
}
