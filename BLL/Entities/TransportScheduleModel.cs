
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;


namespace BLL.Entities
{
    public class TransportScheduleModel
    {
        public int Id { get; set; }

        public Nullable<int> TransportId { get; set; }
        public Nullable<int> FromStoppageId { get; set; }
        public Nullable<int> ToStoppageId { get; set; }
        public string Day { get; set; }
        public Nullable<int> Time { get; set; }
        public TransportModel Transport { get; set; }
        public StoppageModel FromStoppage { get; set; }
        public StoppageModel ToStoppage { get; set; }

        public static TransportScheduleModel FromDb(TransportSchedule transportSchedule, bool extended = false)
        {
            if (transportSchedule == null) return null;
            var model = new TransportScheduleModel()
            {
                Id = transportSchedule.Id,
                TransportId = transportSchedule.TransportId,
                FromStoppageId = transportSchedule.FromStoppageId,
                ToStoppageId = transportSchedule.ToStoppageId,
                Day = transportSchedule.Day,
                Time = transportSchedule.Time
            };
            if (!extended) return model;
            model.Transport = TransportModel.FromDb(transportSchedule.Transport);
            model.FromStoppage = StoppageModel.FromDb(transportSchedule.Stoppage);
            model.ToStoppage = StoppageModel.FromDb(transportSchedule.Stoppage1);

            return model;
        }

        public TransportSchedule GetDbModel()
        {

            return new TransportSchedule() { Id = Id, TransportId = TransportId, FromStoppageId = FromStoppageId, ToStoppageId = ToStoppageId };
        }




    }
}
