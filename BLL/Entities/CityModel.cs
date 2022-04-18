using System.Collections.Generic;
using System.Linq;
using DAL.Database;

namespace BLL.Entities
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<StoppageModel> Stoppages { get; set; }

        public static CityModel FromDb(City city,bool extended=false)
        {
            if (city == null) return null;
            var model = new CityModel()
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country,
            };
            if (extended) model.Stoppages = city.Stoppages.Select(s => StoppageModel.FromDb(s)).ToList();
            return model;
        }

        public City GetDbModel()
        {
            return new City() {Id = Id, Name = Name, Country = Country};
        }
    }
}
