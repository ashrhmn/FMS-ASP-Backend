using DAL.Database;

namespace BLL.Entities
{
    public class TransportScheduleModel
    {
        public int Id { get; set; }
        public int? TransportId { get; set; }
        public int? FromStoppageId { get; set; }
        public int? ToStoppageId { get; set; }
        public string Day { get; set; }
        public int? Time { get; set; }

        public StoppageModel FromStoppage { get; set; }
        public StoppageModel ToStoppage { get; set; }
        public TransportModel Transport { get; set; }

        public static TransportScheduleModel FromDb(TransportSchedule schedule, bool extended = false)
        {
            if (schedule == null) return null;
            var model = new TransportScheduleModel()
            {
                Id = schedule.Id,
                TransportId = schedule.TransportId,
                FromStoppageId = schedule.FromStoppageId,
                ToStoppageId = schedule.ToStoppageId,
                Day = schedule.Day,
                Time = schedule.Time
            };
            if (!extended) return model;
            model.FromStoppage = StoppageModel.FromDb(schedule.Stoppage,true);
            model.ToStoppage = StoppageModel.FromDb(schedule.Stoppage1,true);
            model.Transport = TransportModel.FromDb(schedule.Transport);
            return model;
        }

        public TransportSchedule GetDbModel()
        {
            return new TransportSchedule() { Id = Id, Day = Day, FromStoppageId = FromStoppageId, ToStoppageId = ToStoppageId, Time = Time, TransportId = TransportId };
        }
    }
}