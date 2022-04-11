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
    public class ManagerController : ApiController
    {
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
