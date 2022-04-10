using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Database;

namespace BLL.Entities
{
    public class TransportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Nullable<int> MaximumSeat { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public UserModel CreatedByUser { get; set; }

        public static TransportModel FromDb(Transport transport, bool extended = false)
        {
            if (transport == null) return null;
            var model = new TransportModel()
            {
                Id = transport.Id,
                Name = transport.Name,
                MaximumSeat = transport.MaximumSeat,
                CreatedBy = transport.CreatedBy
            };
            if (!extended) return model;
            model.CreatedByUser = UserModel.FromDb(transport.User);

            return model;
        }

        public Transport GetDbModel()
        {

            return new Transport() { Id = Id, Name = Name, MaximumSeat = MaximumSeat, CreatedBy = CreatedBy };

        }
    }
}
