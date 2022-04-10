using DAL.Database;

namespace BLL.Entities
{
    public class StoppageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public int? RouteIndex { get; set; }
        public int? FareFromRoot { get; set; }
        public CityModel City { get; set; }

        public static StoppageModel FromDb(Stoppage stoppage, bool extended = false)
        {
            if (stoppage == null) return null;
            var model = new StoppageModel()
            {
                Id = stoppage.Id, Name = stoppage.Name, CityId = stoppage.CityId, RouteIndex = stoppage.RouteIndex,
                FareFromRoot = stoppage.FareFromRoot
            };
            if(extended) model.City = CityModel.FromDb(stoppage.City);
            return model;
        }

        public Stoppage GetDbModel()
        {
            return new Stoppage() { Id = Id,Name = Name,CityId = CityId,RouteIndex = RouteIndex,FareFromRoot = FareFromRoot};
        }
    }
}
