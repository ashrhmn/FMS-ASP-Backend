using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.DTOs
{
    public class BookTicketDto
    {
        public string Date { get; set; }
        public int FlightId { get; set; }
        public int UserId { get; set; }
        public string AgeClass { get; set; }
        public string SeatClass { get; set; }
    }
}