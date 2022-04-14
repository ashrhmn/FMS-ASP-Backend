using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL;

namespace BLL.Services
{
    public class AuthService
    {
        public static UserModel Authenticate(string username, string password)
        {
            if (password == null) return null;
            var user =DataAccessFactory.UserDataAccess().GetAll().FirstOrDefault(u => u.Username == username);
            if(user==null) return null;
            return BCrypt.Net.BCrypt.Verify(password, user.Password) ? UserModel.FromDb(user, true) : null;
        }

        public static ResponseModel SendMail(string to, string from,string subject, string body)
        {
            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };

            var credential = new NetworkCredential("fmslaravel@gmail.com", "FmsLaravelApp1234");

            var client = new SmtpClient("smtp.gmail.com",587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = credential,
            };

            try
            {
                client.Send(message);
                return new ResponseModel() { IsSuccess = true,Message = "Mail sent successfully"};
            }
            catch (Exception e)
            {
                return new ResponseModel() {Message = "Error Sending mail : "+e.ToString()};
            }
        }

        public static ResponseModel SendVerificationMail(string to)
        {
            var user = UserService.GetAllUsers().FirstOrDefault(u=>u.Email==to);
            if (user == null) return new ResponseModel(){Message = "User not found with the email"};
            var token = Guid.NewGuid();
            var model = new EmailVerifyTokenModel()
            {
                Token = token.ToString(),
                UserId = user.Id,
            };
            var isAdded = EmailVerifyTokenService.AddToken(model);
            return !isAdded ? new ResponseModel(){Message = "Verification token adding failed"} : SendMail(to, "fmslaravel@gmail.com", "Verify Your FMS Account", "http://localhost:9112/api/auth/verify-email/"+token.ToString());
        }

        public static ResponseModel VerifyEmail(string token)
        {
            var tokenModel = EmailVerifyTokenService.GetByToken(token);
            if (tokenModel == null) return new ResponseModel() {Message = "Invalid token"};
            var user = UserService.GetUser(tokenModel.UserId);
            if (user == null) return new ResponseModel() {Message = "User not found"};
            user.Verified = true;
            var isUserUpdated = UserService.UpdateUser(user.Id, user);
            if(!isUserUpdated) return new ResponseModel() { Message = "Email verification failed" };
            EmailVerifyTokenService.DeleteToken(tokenModel.Id);
            return new ResponseModel() {IsSuccess = true, Message = "Email verified"};
        }
    }
}
