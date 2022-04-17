using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class BookedTicketModel
    {
        public int? Id { get; set; }
        public string FromStoppage { get; set; }
        public string ToStoppageId { get; set; }

        public int SeatId { get; set; }
        public DateTime? StartTime { get; set; }
        public int? SeatNo { get; set; }
        public string TransportName { get; set; }
        public string SeatClass { get; set; }
        public string Status { get; set; }

        public int Fare { get; set; }
        public UserModel PurchasedBy { get; set; }
    }
}
