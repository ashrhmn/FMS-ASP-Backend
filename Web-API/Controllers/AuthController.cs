using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Entities;
using BLL.Services;
using Web_API.Auth;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors("*","*","*")]
    public class AuthController : ApiController
    {
        [Route("sign-in")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginDto loginDto)
        {
            var user = AuthService.Authenticate(loginDto.Username, loginDto.Password);
            if (user == null) return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Username or password is incorrect");
            var payload = new AuthPayload() { Id = user.Id,Username = user.Username,Role = user.RoleEnum,Verified = user.Verified};
            var token = JwtManage.EncodeToken(payload);
            return Request.CreateResponse(HttpStatusCode.OK, new { data= new {user,token} });
        }

        [Route("sign-up")]
        [HttpPost]
        public HttpResponseMessage SignUp([FromBody] UserModel userModel)
        {
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password, 12);
            userModel.Role = 2;
            if (userModel.Email != null) AuthService.SendMail(userModel.Email, "fmslaravel@gmail.com", "Verify your email", "Test Body");
            return UserService.AddUser(userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, userModel)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Sign up failed");
        }

        [Route("current-user")]
        [HttpGet]
        public HttpResponseMessage GetCurrentUser()
        {
            var payload = JwtManage.LoggedInUser((Request.Headers.Authorization).ToString());
            if (payload == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token Invalid");
            var user = UserService.GetUser(payload.Id);
            if (user == null) return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized User");
            var payloadRes = new AuthPayload() {Username = user.Username, Id = user.Id, Role = user.RoleEnum,Verified = user.Verified};
            return Request.CreateResponse(HttpStatusCode.OK, new{data=payloadRes});
        }

        [Route("sign-up/cities")]
        [HttpGet]
        public HttpResponseMessage GetSignUpCities()
        {
            var cities = CityService.GetAllCity();
            return Request.CreateResponse(HttpStatusCode.OK, new{data=cities});
        }

        [Route("verify-email/{token}")]
        [HttpGet]
        public HttpResponseMessage VerifyEmail(string token)
        {
            return Request.CreateResponse(HttpStatusCode.OK,token);
        }

        [Route("send-mail")]
        [HttpPost]
        public HttpResponseMessage SendMail([FromBody] MailModel mail)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AuthService.SendMail(mail.To,mail.From,mail.Subject,mail.Body));
        }
    }
}