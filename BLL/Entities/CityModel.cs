using DAL.Database;

namespace BLL.Entities
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public static CityModel FromDb(City city)
        {
            if (city == null) return null;
            return new CityModel()
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country,
            };
        }

        public City GetDbModel()
        {
            return new City() {Id = Id, Name = Name, Country = Country};
        }
    }
}
