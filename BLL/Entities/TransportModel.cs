using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TransportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> MaximumSeat { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}
