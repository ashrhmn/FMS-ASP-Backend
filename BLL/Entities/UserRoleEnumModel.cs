using DAL.Database;

namespace BLL.Entities
{
    public class UserRoleEnumModel
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public static UserRoleEnumModel FromDb(UserRoleEnum userRoleEnum)
        {
            return userRoleEnum == null ? null : new UserRoleEnumModel() { Id = userRoleEnum.Id, Value = userRoleEnum.Value };
        }

        public UserRoleEnum GetDbModel()
        {
            return new UserRoleEnum() { Id = Id, Value = Value };
        }

    }
}
