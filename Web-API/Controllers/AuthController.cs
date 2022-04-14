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
            var isUserAdded = UserService.AddUser(userModel);
            if(!isUserAdded) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Sign up failed");
            ResponseModel response = null;
            if (userModel.Email != null) response = AuthService.SendVerificationMail(userModel.Email);
            return Request.CreateResponse(HttpStatusCode.Created, new { userModel, response });
        }

        [Route("current-user")]
        [HttpGet]
        public HttpResponseMessage GetCurrentUser()
        {
            if(Request.Headers.Authorization==null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token Not supplied");
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
            return Request.CreateResponse(HttpStatusCode.OK,new{AuthService.VerifyEmail(token).Message});
        }

        [Route("resend-verification-mail")]
        [HttpGet]
        public HttpResponseMessage ResendVerificationMail()
        {
            if (Request.Headers.Authorization == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token Not supplied");
            var payload = JwtManage.LoggedInUser((Request.Headers.Authorization).ToString());
            if (payload == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token Invalid");
            var user = UserService.GetUser(payload.Id);
            if (user == null) return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized User");
            EmailVerifyTokenService.DeleteTokenByUser(user.Id);
            return user.Email==null ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Email") : Request.CreateResponse(HttpStatusCode.OK, AuthService.SendVerificationMail(user.Email));
        }
    }
}