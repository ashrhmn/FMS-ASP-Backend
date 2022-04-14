using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Services;
using Web_API.Auth;

namespace Web_API.Controllers
{
    [UserAccess]
    [RoutePrefix("api/user-db")]
    [EnableCors("*","*","*")]
    public class UserDashboardController : ApiController
    {
        [Route("flights")]
        public HttpResponseMessage GetAllFlightSchedule()
        {
            var schedules = TransportScheduleService.GetAllTransportSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = schedules });
        }
    }
}