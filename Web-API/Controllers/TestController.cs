using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("next/{day}")]
        [HttpGet]
        public HttpResponseMessage TestDate(string day)
        {
            var next = UtilsService.GetNextWeekDay(day);
            return next == null
                ? Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid day")
                : Request.CreateResponse(HttpStatusCode.OK, next);
        }

        [Route("next/date")]
        [HttpPost]
        public HttpResponseMessage TestDay(DateTimeDto dateTimeDto)
        {
            var next = UtilsService.GetNextWeekDate(dateTimeDto.Date);
            return next == null
                ? Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid day")
                : Request.CreateResponse(HttpStatusCode.OK, next);
        }
    }
}