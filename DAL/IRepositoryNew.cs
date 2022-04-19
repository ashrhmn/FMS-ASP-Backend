using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepositoryNew<T,TId>
    {
        List<T> GetAll();
        T GetById(TId id);
        T Add(T obj);
        bool Update(TId id, T obj);
        bool Delete(TId id);
    }
}
