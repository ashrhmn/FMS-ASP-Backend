using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Entities;
using BLL.Services;

namespace Web_API.Controllers
{
    public class TransportScheduleController : ApiController
    {
        // GET api/transportschedule
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportScheduleService.GetAllTransportSchedule());
        }

        // GET api/transportschedule/{id}
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportScheduleService.GetTransportSchedule(id));
        }

        // POST api/transportschedule
        public HttpResponseMessage Post([FromBody] TransportScheduleModel transportScheduleModel)
        {
            return TransportScheduleService.AddTransportSchedule(transportScheduleModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Transport Schedule");
        }

        // PUT api/transportschedule/{id}
        public HttpResponseMessage Put(int id, [FromBody] TransportScheduleModel transportScheduleModel)
        {
            return TransportScheduleService.UpdateTransportSchedule(id,transportScheduleModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Transport Schedule");
        }

        // DELETE api/transportschedule/{id}
        public HttpResponseMessage Delete(int id)
        {
            return TransportScheduleService.DeleteTransportSchedule(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Transport Schedule");
        }
    }
}
