using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class CityService
    {
        public static List<CityModel> GetAllCity()
        {

            return DataAccessFactory.CityDataAccess().GetAll().Select(city => CityModel.FromDb(city)).ToList();
        }

        public static CityModel GetCity(int id)
        {
            return CityModel.FromDb(DataAccessFactory.CityDataAccess().GetById(id));
        }

        public static bool AddCity(CityModel cityModel)
        {
            return DataAccessFactory.CityDataAccess().Add(cityModel.GetDbModel());
        }

        public static bool UpdateCity(int id,CityModel cityModel)
        {
            return DataAccessFactory.CityDataAccess().Update(id,cityModel.GetDbModel());
        }

        public static bool DeleteCity(int id)
        {
            return DataAccessFactory.CityDataAccess().Delete(id);
        }
    }
}
