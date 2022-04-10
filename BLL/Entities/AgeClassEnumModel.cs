using DAL.Database;

namespace BLL.Entities
{
    public class AgeClassEnumModel
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public static AgeClassEnumModel FromDb(AgeClassEnum ageClassEnum)
        {
            return ageClassEnum == null ? null : new AgeClassEnumModel(){ Id = ageClassEnum.Id,Value = ageClassEnum.Value};
        }

        public AgeClassEnum GetDbModel()
        {
            return new AgeClassEnum() { Id = Id,Value = Value};
        }
    }
}
