using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using Web_API.Auth;

namespace Web_API.Controllers
{
    [AdminAccess]
    [RoutePrefix("api/admin-db")]
    public class AdminDashboardController : ApiController
    {
        [Route("transports")]
        [HttpGet]
        public HttpResponseMessage GetTransports()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { data=TransportService.GetAllTransport() });
        }

        [Route("cities")]
        [HttpGet]
        public HttpResponseMessage GetCities()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { data = CityService.GetAllCity() });
        }

        [Route("users")]
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { data = UserService.GetAllUsers() });
        }
    }
}