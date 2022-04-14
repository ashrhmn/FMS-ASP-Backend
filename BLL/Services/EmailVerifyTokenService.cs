using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class EmailVerifyTokenService
    {
        public static bool AddToken(EmailVerifyTokenModel emailVerifyTokenModel)
        {
            DeleteTokenByUser(emailVerifyTokenModel.UserId);
            return DataAccessFactory.EmailVerifyTokenAccess().Add(emailVerifyTokenModel.GetDbModel());
        }

        public static EmailVerifyTokenModel GetById(int id)
        {
            return EmailVerifyTokenModel.FromDb(DataAccessFactory.EmailVerifyTokenAccess().GetById(id));
        }

        public static EmailVerifyTokenModel GetByToken(string token)
        {
            return EmailVerifyTokenModel
                .FromDb(DataAccessFactory.EmailVerifyTokenAccess().GetAll().FirstOrDefault(t => t.Token == token));
        }
        public static List<EmailVerifyTokenModel> GetByUserId(int userId)
        {
            return DataAccessFactory.
                EmailVerifyTokenAccess().
                GetAll().
                Where(t => t.UserId == userId).
                Select(tm => EmailVerifyTokenModel.FromDb(tm))
                .ToList();
        }

        public static bool DeleteToken(int id)
        {
            return DataAccessFactory.EmailVerifyTokenAccess().Delete(id);
        }

        public static bool DeleteTokenByUser(int userId)
        {
            var tokens = DataAccessFactory.EmailVerifyTokenAccess().GetAll().Where(t => t.UserId == userId).ToList();
            foreach (var token in tokens)
            {
                DataAccessFactory.EmailVerifyTokenAccess().Delete(token.Id);
            }

            return true;
        }
    }
}
