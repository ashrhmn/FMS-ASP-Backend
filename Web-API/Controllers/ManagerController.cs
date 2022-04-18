using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Entities;
using BLL.Services;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    public class ManagerController : ApiController
    {

        [Route("api/manager/profile")]
        [HttpGet]
        public HttpResponseMessage Profile()
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.ManagerProfile(24));
        }

        [Route("api/manager/editprofile")]
        [HttpPost]
        public HttpResponseMessage EditProfile([FromBody] UserModel userModel)
        {
            return ManagerService.UpdateProfile(userModel.Id, userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Profile");
        }

        [Route("api/manager/changepass")]
        [HttpPost]
        public HttpResponseMessage ChangePass(ChangePassDto changePass)
        {
            return Request.CreateResponse(HttpStatusCode.Created, ManagerService.ChangePass(24, changePass.OldPassword, changePass.Password, changePass.ConPassword));
        }

        [Route("api/manager/userlistsearch")]
        [HttpPost]
        public HttpResponseMessage UserListSearch(UListSearchDto uListSearch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.UserlistSearch(uListSearch.Uname, uListSearch.Purchase));
        }

        [Route("api/manager/flightmanagerlistsearch")]
        [HttpPost]
        public HttpResponseMessage FlightManagerListSearch(UListSearchDto uListSearchDto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.FlightManagerlistSearch(uListSearchDto.Uname));
        }

        [Route("api/manager/userprofile/{id}")]
        [HttpGet]
        public HttpResponseMessage UserProfile(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.GetUser(id));
        }

        [Route("api/manager/edituserprofile")]
        [HttpPost]
        public HttpResponseMessage EditUserProfile([FromBody] UserModel userModel)
        {
            return ManagerService.UpdateUserdetails(userModel.Id, userModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Profile");
        }


        [Route("api/manager/userticketlist/{id}")]
        [HttpGet]
        public HttpResponseMessage UserTickets(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.UserTicketList(id));
        }


        [Route("api/manager/updateticket")]
        [HttpPost]
        public HttpResponseMessage EditTicket(UpdateTickettDto updateTickettDto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.UpdateTicket(updateTickettDto.Id, updateTickettDto.AgeClass, updateTickettDto.SeatClass));
        }


        [Route("api/manager/Flightlist")]
        [HttpGet]
        public HttpResponseMessage FlightList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.GetAllTransportSchedule());
        }


        [Route("api/manager/cancelticket/{uid}/{tid}")]
        [HttpGet]
        public HttpResponseMessage FlightList(int uid, int tid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.CancelTicket(uid,tid));

        }


        [Route("api/manager/adduser")]
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] UserModel userModel)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.AddUser(userModel));
        }

        [Route("api/manager/deleteuser/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteUser(int id)
        {
            return ManagerService.DeleteUser(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted User Account Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting User");
        }

        [Route("api/manager/aircraftlistsearch")]
        [HttpPost]
        public HttpResponseMessage AircraftList([FromBody] AircraftlistSearchDto aircraft)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.AircraftListSearch(aircraft.Name));
        }



















        [Route("api/get/seatinfos")]
        [HttpGet]
        public HttpResponseMessage GetAllSeatInfo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SeatInfoService.GetAllSeatInfos());
        }

        [Route("api/get/seatinfo/{id}")]
        [HttpGet]
        public HttpResponseMessage GetSeatInfo(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, SeatInfoService.GetSeatInfo(id));
        }

        [Route("api/add/seatinfo")]
        [HttpPost]
        public HttpResponseMessage AddSeatInfo([FromBody] SeatInfoModel seatinfotModel)
        {
            return SeatInfoService.AddSeatInfo(seatinfotModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding SeatInfo");
        }

        [Route("api/edit/seatinfo")]
        [HttpPost]
        public HttpResponseMessage UpdateSeatInfo([FromBody] SeatInfoModel seatinfoModel)
        {
            return SeatInfoService.UpdateSeatInfo(seatinfoModel.Id, seatinfoModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating SeatInfo");
        }

        [Route("api/delete/seatinfo/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteSeatInfo(int id)
        {
            return SeatInfoService.DeleteSeatInfo(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting SeatInfo");
        }






        [Route("api/get/families")]
        [HttpGet]
        public HttpResponseMessage GetAllFamily()
        {
            return Request.CreateResponse(HttpStatusCode.OK, FamilyService.GetAllFamily());
        }

        [Route("api/get/family/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFamily(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, FamilyService.GetFamily(id));
        }

        [Route("api/add/family")]
        [HttpPost]
        public HttpResponseMessage AddFamily([FromBody] FamilyModel familyModel)
        {
            return FamilyService.AddFamily(familyModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Family");
        }

        [Route("api/edit/fammily")]
        [HttpPost]
        public HttpResponseMessage UpdateFamily([FromBody] FamilyModel familyModel)
        {
            return FamilyService.UpdateFamily(familyModel.Id, familyModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Family");
        }

        [Route("api/delete/family/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteFamily(int id)
        {
            return FamilyService.DeleteFamily(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting Family");
        }

    }
}
