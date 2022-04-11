using System;
using DAL.Database;

namespace BLL.Entities
{
    public class SeatInfoModel
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public int? SeatNo { get; set; }
        public int? TicketId { get; set; }
        public int? TransportId { get; set; }
        public int? AgeClass { get; set; }
        public int? SeatClass { get; set; }
        public string Status { get; set; }

        public AgeClassEnumModel AgeClassEnum { get; set; }
        public PurchasedTicketModel PurchasedTicket { get; set; }
        public SeatClassEnumModel SeatClassEnum { get; set; }
        public TransportModel Transport { get; set; }

        public static SeatInfoModel FromDb(SeatInfo seatInfo, bool extended = false)
        {
            if (seatInfo == null) return null;
            var model = new SeatInfoModel() { Id = seatInfo.Id, StartTime = seatInfo.StartTime,SeatNo = seatInfo.SeatNo,TicketId = seatInfo.TicketId,TransportId = seatInfo.TransportId,AgeClass = seatInfo.AgeClass,SeatClass = seatInfo.SeatClass,Status = seatInfo.Status};
            if (!extended) return model;
            model.PurchasedTicket = PurchasedTicketModel.FromDb(seatInfo.PurchasedTicket);
            model.AgeClassEnum = AgeClassEnumModel.FromDb(seatInfo.AgeClassEnum);
            model.SeatClassEnum = SeatClassEnumModel.FromDb(seatInfo.SeatClassEnum);
            model.Transport = TransportModel.FromDb(seatInfo.Transport);
            return model;
        }

        public SeatInfo GetDbModel()
        {
            return new SeatInfo() { Id = Id,TransportId = TransportId,AgeClass = AgeClass,SeatClass = SeatClass,SeatNo = SeatNo,StartTime = StartTime,Status = Status,TicketId = TicketId};
        }
    }
}
