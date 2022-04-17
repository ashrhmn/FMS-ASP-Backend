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
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("dashboard")]
        [HttpPost]
        public HttpResponseMessage Dashboard([FromBody] TransportModel transportModel)
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("transports")]
        [HttpGet]
        public HttpResponseMessage GetAllTransports()
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("transport/{id}")]
        [HttpGet]
        public HttpResponseMessage GetTransport(int tid)
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("transports/{id}")]
        [HttpPost]
        public HttpResponseMessage UpdateTransport([FromBody] TransportModel transportModel)
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
        }

        [Route("bookedtickets")]
        [HttpGet]
        public HttpResponseMessage BookedTickets()
        {
            var transports = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = transports });
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
