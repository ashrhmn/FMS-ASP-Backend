using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using Web_API.Auth;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginDto loginDto)
        {
            var user = AuthService.Authenticate(loginDto.Username, loginDto.Password);
            if (user == null) return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Username or password is incorrect");
            var payload = new AuthPayload() { Id = user.Id,Username = user.Username,Role = user.RoleEnum};
            var token = JwtManage.EncodeToken(payload);
            return Request.CreateResponse(HttpStatusCode.OK, new { data= new {user,token} });
        }
    }
}