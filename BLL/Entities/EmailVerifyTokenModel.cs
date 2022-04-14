using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace BLL.Entities
{
    public class EmailVerifyTokenModel
    {
        public int  Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public static EmailVerifyTokenModel FromDb(EmailVerifyToken emailVerifyToken, bool extended = false)
        {
            if (emailVerifyToken == null) return null;
            var model = new EmailVerifyTokenModel()
            {
                Id = emailVerifyToken.Id,
                Token = emailVerifyToken.Token,
                UserId = emailVerifyToken.UserId
            };
            if(extended) model.User = UserModel.FromDb(emailVerifyToken.User);
            return model;
        }

        public EmailVerifyToken GetDbModel()
        {
            return new EmailVerifyToken()
            {
                Id = Id,
                Token = Token,
                UserId = UserId
            };
        }
    }
}
