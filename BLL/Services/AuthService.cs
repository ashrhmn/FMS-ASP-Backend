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

        public static string SendMail(string to, string from,string subject, string body)
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
                return "Message Sent";
            }
            catch (Exception e)
            {
                return "Error : "+e.ToString();
            }
        }
    }
}
