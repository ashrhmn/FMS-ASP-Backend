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
    }
}
