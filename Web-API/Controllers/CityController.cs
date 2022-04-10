using BLL.Entities;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class CityController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CityService.GetAllCity());
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, CityService.GetCity(id));
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] CityModel cityModel)
        {
            return CityService.AddCity(cityModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user");
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] CityModel cityModel)
        {
            return CityService.UpdateCity(id,cityModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            return CityService.DeleteCity(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting user");
        }
    }
}
