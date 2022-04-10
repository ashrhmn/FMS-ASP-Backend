using BLL.Entities;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class TicketController : ApiController
    {
        // GET api/ticket
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TicketService.GetAllTicket());
        }

        // GET api/ticket/{id}
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TicketService.GetTicket(id));
        }

        // POST api/ticket
        public HttpResponseMessage Post([FromBody] PurchasedTicketModel ticketModel)
        {
            return TicketService.AddTicket(ticketModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user");
        }

        // PUT api/ticket/{id}
        public HttpResponseMessage Put(int id, [FromBody] PurchasedTicketModel ticketModel)
        {
            return TicketService.UpdateTicket(id,ticketModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }

        // DELETE api/ticket/{id}
        public HttpResponseMessage Delete(int id)
        {
            return TicketService.DeleteTicket(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting user");
        }
    }
}
