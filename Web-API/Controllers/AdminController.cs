using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Entities;
using BLL.Services;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    public class AdminController : ApiController
    {
        [Route("api/admin/getallusers")]
        [HttpGet]
        public HttpResponseMessage GetAllUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetAllUsers());
        }
        [Route("api/admin/getalladmins")]
        [HttpGet]
        public HttpResponseMessage GetAllAdmins()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.GetAllAdmin());
        }
        [Route("api/admin/getallcustomers")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.GetAllCustomer());
        }
        [Route("api/admin/getallflightmanagers")]
        [HttpGet]
        public HttpResponseMessage GetAllFlightManagers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.GetAllFlightManager());
        }
        [Route("api/admin/getallmanagers")]
        [HttpGet]
        public HttpResponseMessage GetAllManagers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.GetAllManager());
        }
        [Route("api/admin/getuser/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetUser(id));
        }
        [Route("api/admin/adduser")]
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] UserModel userModel)
        {
            return UserService.AddUser(userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user");
        }
        [Route("api/admin/edituser/{id}")]
        [HttpPost]
        public HttpResponseMessage EditUser(int id, [FromBody] UserModel userModel)
        {
            return UserService.UpdateUser(id, userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }
        [Route("api/admin/deleteuser/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteUser(int id)
        {
            return UserService.DeleteUser(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting user");
        }
        [Route("api/admin/getallaircrafts")]
        [HttpGet]
        public HttpResponseMessage GetAllAircrafts()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportService.GetAllTransport());
        }

        [Route("api/admin/getaircraft/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAircraft(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportService.GetTransport(id));
        }

        [Route("api/admin/addaircraft")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TransportModel transportModel)
        {
            return TransportService.AddTransport(transportModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Transport");
        }

        [Route("api/admin/editaircraft/{id}")]
        [HttpPost]
        public HttpResponseMessage Put(int id, [FromBody] TransportModel transportModel)
        {
            return TransportService.UpdateTransport(id, transportModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Transport");
        }

        [Route("api/admin/deleteaircraft/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            return TransportService.DeleteTransport(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Transport");
        }
        //[Route("api/admin/bookedaircraftseats/{id}")]
        //[HttpGet]
        //public HttpResponseMessage BookedAircraftSeats(int id)
        //{
        //    return SeatInfoService.BookedAircraftSeats(id)
        //        ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
        //        : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Transport");
        //}
        // GET api/transportschedule
        [Route("api/admin/getschedules")]
        [HttpGet]
        public HttpResponseMessage GetAllSchedules()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportScheduleService.GetAllTransportSchedule());
        }

        [Route("api/admin/getschedule/{id}")]
        [HttpGet]
        public HttpResponseMessage GetSchedules(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransportScheduleService.GetTransportSchedule(id));
        }

        [Route("api/admin/addschedule")]
        [HttpPost]
        public HttpResponseMessage AddSchedules([FromBody] TransportScheduleModel transportScheduleModel)
        {
            return TransportScheduleService.AddTransportSchedule(transportScheduleModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Transport Schedule");
        }

        [Route("api/admin/editschedule/{id}")]
        [HttpGet]
        public HttpResponseMessage EditSchedules(int id, [FromBody] TransportScheduleModel transportScheduleModel)
        {
            return TransportScheduleService.UpdateTransportSchedule(id, transportScheduleModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Transport Schedule");
        }

        [Route("api/admin/deleteschedule/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteSchedules(int id)
        {
            return TransportScheduleService.DeleteTransportSchedule(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Transport Schedule");
        }
        [Route("api/admin/getallstoppages")]
        [HttpGet]
        public HttpResponseMessage GetAllStoppage()
        {
            return Request.CreateResponse(HttpStatusCode.OK, StoppageService.GetAllStoppage());
        }

        [Route("api/admin/getstoppage/{id}")]
        [HttpGet]
        public HttpResponseMessage GetStoppage(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, StoppageService.GetStoppage(id));
        }

        [Route("api/admin/addstoppage")]
        [HttpPost]
        public HttpResponseMessage AddStoppage([FromBody] StoppageModel stoppageModel)
        {
            return StoppageService.AddStoppage(stoppageModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user");
        }

        [Route("api/admin/editstoppage/{id}")]
        [HttpPost]
        public HttpResponseMessage UpdateStoppage(int id, [FromBody] StoppageModel stoppageModel)
        {
            return StoppageService.UpdateStoppage(id, stoppageModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user");
        }

        [Route("api/admin/deletestoppage/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteStoppage(int id)
        {
            return StoppageService.DeleteStoppage(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting user");
        }

        [Route("api/admin/bookedseatsforflights/{id}")]
        [HttpGet]
        public HttpResponseMessage BookedSeatsForFlight(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.BookedSeatsForFlight(id));
        }
        [Route("api/admin/searchflight")]
        [HttpPost]
        public HttpResponseMessage SearchFlight([FromBody] SearchWithNameDto a)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.SearchFlight(a.Name));

        }
        [Route("api/admin/searchusers")]
        [HttpPost]
        public HttpResponseMessage SearchUser([FromBody] SearchWithNameDto a)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminService.SearchUser(a.Name));

        }
    }

}