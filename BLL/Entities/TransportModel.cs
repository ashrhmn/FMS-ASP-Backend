using System.Collections.Generic;
using System.Linq;
using DAL.Database;

namespace BLL.Entities
{
    public class TransportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MaximumSeat { get; set; }
        public int? CreatedBy { get; set; }
        public UserModel CreatedByUser { get; set; }
        public List<SeatInfoModel> SeatInfos { get; set; } = new List<SeatInfoModel>();
        public List<TransportScheduleModel> TransportSchedules { get; set; } = new List<TransportScheduleModel>();

        public static TransportModel FromDb(Transport transport, bool extended = false)
        {
            if (transport == null) return null;
            var model = new TransportModel() { Id = transport.Id, Name = transport.Name, MaximumSeat = transport.MaximumSeat, CreatedBy = transport.CreatedBy };
            if (!extended) return model;
            model.CreatedByUser = UserModel.FromDb(transport.User);
            model.SeatInfos = transport.SeatInfos.Select(si => SeatInfoModel.FromDb(si)).ToList();
            model.TransportSchedules =
                transport.TransportSchedules.Select(ts => TransportScheduleModel.FromDb(ts)).ToList();
            return model;
        }

        public Transport GetDbModel()
        {
            return new Transport() { Id = Id, CreatedBy = CreatedBy, MaximumSeat = MaximumSeat, Name = Name };
        }
    }
}