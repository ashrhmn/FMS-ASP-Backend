using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.DTOs
{
    public class FlightSearchDto
    {
        public string Date { get; set; }
        public string FromStopage { get; set; }
        public string ToStopage { get; set; }
    }
}