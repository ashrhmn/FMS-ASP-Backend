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
    public class TransportController : ApiController
    {
        // GET api/transport
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportService.GetAllTransport());
        }

        // GET api/transport/{id}
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportService.GetTransport(id));
        }

        // POST api/transport
        public HttpResponseMessage Post([FromBody] TransportModel transportModel)
        {
            return TransportService.AddTransport(transportModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Transport");
        }

        // PUT api/transport/{id}
        public HttpResponseMessage Put(int id, [FromBody] TransportModel transportModel)
        {
            return TransportService.UpdateTransport(id,transportModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Transport");
        }

        // DELETE api/transport/{id}
        public HttpResponseMessage Delete(int id)
        {
            return TransportService.DeleteTransport(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Transport");
        }
    }
}
