using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class SeatInfoModel
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<int> SeatNo { get; set; }
        public Nullable<int> TicketId { get; set; }
        public Nullable<int> TransportId { get; set; }
        public Nullable<int> AgeClass { get; set; }
        public Nullable<int> SeatClass { get; set; }
        public string Status { get; set; }

        public virtual AgeClassEnumModel AgeClassEnum { get; set; }
        public virtual PurchasedTicketModel PurchasedTicket { get; set; }
        public virtual SeatClassEnumModel SeatClassEnum { get; set; }
        public virtual TransportModel Transport { get; set; }
    }
}
