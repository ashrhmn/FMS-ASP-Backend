using DAL.Database;

namespace BLL.Entities
{
    public class FamilyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static FamilyModel FromDb(Family family)
        {
            if (family == null) return null;
            return family == null ? null : new FamilyModel() { Id = family.Id,Name = family.Name};

        }

        public Family GetDbModel()
        {
            return new Family() {Id = Id, Name = Name};
        }
    }
}
