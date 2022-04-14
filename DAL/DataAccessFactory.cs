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

        public static IRepository<Stoppage, int> StoppageDataAccess()
        {
            return new StoppageRepo(Db);
        }

        public static IRepository<PurchasedTicket, int> TicketDataAccess()
        {
            return new TicketRepo(Db);
        }

        public static IRepository<SeatInfo, int> SeatInfoDataAccess()
        {
            return new SeatInfoRepo(Db);
        }
        public static IRepository<Transport, int> TransportDataAccess()
        {
            return new TransportRepo(Db);
        }
        public static IRepository<TransportSchedule, int> TransportScheduleDataAccess()
        {
            return new TransportScheduleRepo(Db);
        }
        public static IRepository<Family, int> FamilyDataAccess()
        {
            return new FamilyRepo(Db);
        }

        public static IRepository<EmailVerifyToken, int> EmailVerifyTokenAccess()
        {
            return new EmailVerifyTokenRepo(Db);
        }

    }
}
