using DAL.Database;
using DAL.Repo;

namespace DAL
{
    public class DataAccessFactory
    {
        private static readonly FmsEntities Db = new FmsEntities();

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(Db);
        }

        public static IRepository<City, int> CityDataAccess()
        {
            return new CityRepo(Db);
        }
    }
}
