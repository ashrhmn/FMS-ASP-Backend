using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Entities;
using BLL.Services;
using Web_API.Auth;
using Web_API.Models;

namespace Web_API.Controllers
{
    [AuthorizedAccess("user")]
    public class UserController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var user = RoleConst.User();
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetAllUsers());
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetUser(id));
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] UserModel userModel)
        {
            return UserService.AddUser(userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user");
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] UserModel userModel)
        {
            return UserService.UpdateUser(id,userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            return UserService.DeleteUser(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting user");
        }
    }
}