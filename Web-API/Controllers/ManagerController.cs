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
        // GET api/seatinfo
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SeatInfoService.GetAllSeatInfos());
        }

        // GET api/seatinfo/{id}
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, SeatInfoService.GetSeatInfo(id));
        }

        // POST api/seatinfo
        public HttpResponseMessage Post([FromBody] SeatInfoModel seatinfotModel)
        {
            return SeatInfoService.AddSeatInfo(seatinfotModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Added successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding SeatInfo");
        }

        // PUT api/seatinfo/{id}
        public HttpResponseMessage Put(int id, [FromBody] SeatInfoModel seatinfoModel)
        {
            return SeatInfoService.UpdateSeatInfo(id, seatinfoModel)
                ? Request.CreateResponse(HttpStatusCode.Created, "Updated successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating SeatInfo");
        }

        // DELETE api/seatinfo/{id}
        public HttpResponseMessage Delete(int id)
        {
            return SeatInfoService.DeleteSeatInfo(id)
                ? Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully")
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting SeatInfo");
        }
    }
}
