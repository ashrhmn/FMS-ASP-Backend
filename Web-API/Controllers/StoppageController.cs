using BLL.Entities;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class StoppageController : ApiController
    {
        // GET api/stoppage
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, StoppageService.GetAllStoppage());
        }

        // GET api/stoppage/{id}
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, StoppageService.GetStoppage(id));
        }

        // POST api/stoppage
        public HttpResponseMessage Post([FromBody] StoppageModel stoppageModel)
        {
            return StoppageService.AddStoppage(stoppageModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user");
        }

        // PUT api/stoppage/{id}
        public HttpResponseMessage Put(int id, [FromBody] StoppageModel stoppageModel)
        {
            return StoppageService.UpdateStoppage(id,stoppageModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }

        // DELETE api/stoppage/{id}
        public HttpResponseMessage Delete(int id)
        {
            return StoppageService.DeleteStoppage(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting user");
        }
    }
}
