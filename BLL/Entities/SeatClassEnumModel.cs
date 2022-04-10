using DAL.Database;

namespace BLL.Entities
{
    public class SeatClassEnumModel
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public static SeatClassEnumModel FromDb(SeatClassEnum seatClassEnum)
        {
            return seatClassEnum == null ? null : new SeatClassEnumModel() { Id = seatClassEnum.Id,Value = seatClassEnum.Value};
        }

        public SeatClassEnum GetDbModel()
        {
            return new SeatClassEnum() { Id = Id,Value = Value};
        }
    }
}
