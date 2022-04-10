using System.Collections.Generic;
using System.Linq;
using DAL.Database;

namespace BLL.Entities
{
    public class PurchasedTicketModel
    {
        public int Id { get; set; }
        public int FromStoppageId { get; set; }
        public int ToStoppageId { get; set; }
        public int PurchasedBy { get; set; }
        public StoppageModel FromStoppage { get; set; }
        public StoppageModel ToStoppage { get; set; }
        public UserModel PurchasedByUser { get; set; }
        public List<SeatInfoModel> SeatInfos { get; set; } = new List<SeatInfoModel>();


        public static PurchasedTicketModel FromDb(PurchasedTicket purchasedTicket, bool extended = false)
        {
            if (purchasedTicket == null) return null;
            var model = new PurchasedTicketModel()
            {
                Id = purchasedTicket.Id, FromStoppageId = purchasedTicket.FromStoppageId,
                ToStoppageId = purchasedTicket.ToStoppageId, PurchasedBy = purchasedTicket.PurchasedBy
            };
            if (!extended) return model;
            model.FromStoppage = StoppageModel.FromDb(purchasedTicket.Stoppage);
            model.ToStoppage = StoppageModel.FromDb(purchasedTicket.Stoppage1);
            model.PurchasedByUser = UserModel.FromDb(purchasedTicket.User);
            model.SeatInfos = purchasedTicket.SeatInfos.Select(si => SeatInfoModel.FromDb(si)).ToList();
            return model;
        }

        public PurchasedTicket GetDbModel()
        {
            return new PurchasedTicket() { Id = Id,FromStoppageId = FromStoppageId, ToStoppageId = ToStoppageId,PurchasedBy = PurchasedBy};
        }
    }
}
