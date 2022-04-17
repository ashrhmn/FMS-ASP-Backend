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

        [Route("addtransport")]
        [HttpGet]
        public HttpResponseMessage AddTransport([FromBody] TransportModel tm)
        {
            AuthPayload user = JwtManage.LoggedInUser(Request.Headers.Authorization.ToString());
            tm.CreatedBy = user.Id;
            return TransportService.AddTransport(tm)
                ? Request.CreateResponse(HttpStatusCode.Created, "Transport added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error ading transport");
        }

        [Route("transport/{id}")]
        [HttpGet]
        public HttpResponseMessage GetTransport(int id)
        {
            var transport = TransportService.GetTransport(id);
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transport });
        }

        [Route("transport/{id}")]
        [HttpPost]
        public HttpResponseMessage UpdateTransport(int id, [FromBody] TransportModel tm)
        {
            AuthPayload user = JwtManage.LoggedInUser(Request.Headers.Authorization.ToString());
            tm.CreatedBy = user.Id;

            return TransportService.UpdateTransport(id, tm)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating transport");
        }

        [Route("transport/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteTransport(int id)
        {

            return TransportService.DeleteTransport(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting transport");
        }

        [Route("addschedule/{id}")]
        [HttpGet]
        public HttpResponseMessage AddSchedule(int id, [FromBody] TransportScheduleModel tcm)
        {
            tcm.TransportId = id;
            return TransportScheduleService.AddTransportSchedule(tcm)
                ? Request.CreateResponse(HttpStatusCode.Created, "Schedule added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding transport schedule");
        }

        [Route("transportschedule/{id}")]
        [HttpPost]
        public HttpResponseMessage UpdateSchedule(int id, [FromBody] TransportScheduleModel tcm)
        {
            tcm.TransportId = id;
            return TransportScheduleService.UpdateTransportSchedule(id,tcm)
                ? Request.CreateResponse(HttpStatusCode.Created, "Schedule updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updateing transport schedule");
        }

        [Route("transportschedule/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteSchedule(int id)
        {

            return TransportScheduleService.DeleteTransportSchedule(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting transport schedule");
        }

        [Route("addstoppage")]
        [HttpGet]
        public HttpResponseMessage AddStopage([FromBody] StoppageModel sm)
        {
            return StoppageService.AddStoppage(sm)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding stoppage");
        }

        [Route("tickets/{booked}")]
        [HttpGet]
        public HttpResponseMessage Tickets( bool booked)
        {
            AuthPayload user = JwtManage.LoggedInUser(Request.Headers.Authorization.ToString());
            var tkts = FMService.GetTickets(user.Id, booked);
            return Request.CreateResponse(HttpStatusCode.OK, new { data = tkts });
        }

        [Route("ticket/{id}")]
        [HttpGet]
        public HttpResponseMessage Ticket(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, FMService.GetTicket(id));
        }

        [Route("ticket/{id}")]
        [HttpPost]
        public HttpResponseMessage UpdateTicket(int id, [FromBody] SeatInfoModel sim)
        {
            return FMService.UpdateTicket(id, sim)
                ? Request.CreateResponse(HttpStatusCode.Created, "Ticket updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updateing Ticket");
        }

        [Route("ticket/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteTicket(int id)
        {
            return FMService.DeleteTicket(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Ticket deleted successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Ticket");
        }

    }
}
