using BLL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FamilyService
    {
        public static List<FamilyModel> GetAllFamily()
        {

            return DataAccessFactory.FamilyDataAccess().GetAll().Select(family => FamilyModel.FromDb(family)).ToList();
        }

        public static FamilyModel GetFamily(int id)
        {
            return FamilyModel.FromDb(DataAccessFactory.FamilyDataAccess().GetById(id));
        }

        public static bool AddFamily(FamilyModel familyModel)
        {
            return DataAccessFactory.FamilyDataAccess().Add(familyModel.GetDbModel());
        }

        public static bool UpdateFamily(int id, FamilyModel familyModel)
        {
            return DataAccessFactory.FamilyDataAccess().Update(id, familyModel.GetDbModel());
        }

        public static bool DeleteFamily(int id)
        {
            return DataAccessFactory.FamilyDataAccess().Delete(id);
        }
    }
}
