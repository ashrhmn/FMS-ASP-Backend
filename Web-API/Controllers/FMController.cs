using BLL.Entities;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_API.Auth;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    [FMAccess]
    [RoutePrefix("api/fm")]
    [EnableCors("*", "*", "*")]
    public class FMController : ApiController
    {
        [Route("dashboard")]
        [HttpGet]
        public HttpResponseMessage Dashboard()
        {
            AuthPayload user = JwtManage.LoggedInUser(Request.Headers.Authorization.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, FMService.Profile(user.Id));
        }

        [Route("dashboard")]
        [HttpPost]
        public HttpResponseMessage Dashboard( [FromBody] ProfileDto profile)
        {
            AuthPayload user = JwtManage.LoggedInUser(Request.Headers.Authorization.ToString());
            var UM = new UserModel()
            {
                Id = user.Id,
                Name = profile.Name,
                Username = profile.Username,
                Password = profile.Password,
                Address = profile.Address,
                DateOfBirth = profile.DateOfBirth,
                CityId = profile.CityId,
                FamilyId = profile.FamilyId,
                Role = 3,
                Email = profile.Email,
                Phone = profile.Phone
            };

            return FMService.UpdateProfile(user.Id, UM, profile.ConfirmPassword)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }

        [Route("transports")]
        [HttpGet]
        public HttpResponseMessage GetAllTransports()
        {
            AuthPayload user = JwtManage.LoggedInUser(Request.Headers.Authorization.ToString());
            var transports = FMService.GetAllTransport(user.Id);
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        //[Route("transport/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetTransport(int tid)
        //{
        //    var transport = TransportService.GetTransport(tid);
        //    return Request.CreateResponse(HttpStatusCode.OK, new { data = transport });
        //}

        [Route("transport/{id}")]
        [HttpGet]
        public HttpResponseMessage GetTransport(int tid)
        {
            var transport = TransportService.GetTransport(tid);
            return Request.CreateResponse(HttpStatusCode.OK, TransportService.GetTransport(tid));
        }

        [Route("bookedtickets")]
        [HttpGet]
        public HttpResponseMessage BookedTickets()
        {
            var btkts = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = btkts });
        }

        [Route("bookedticket/{id}")]
        [HttpGet]
        public HttpResponseMessage BookedTicket(int tid)
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("payments")]
        [HttpGet]
        public HttpResponseMessage Payments()
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("payment/{id}")]
        [HttpGet]
        public HttpResponseMessage Payment(int id)
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("search")]
        [HttpGet]
        public HttpResponseMessage UserListSearch(UListSearchDto uListSearch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.UserlistSearch(uListSearch.Uname, uListSearch.Purchase));
        }
    }
}
