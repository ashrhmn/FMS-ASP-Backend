using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T, in TId>
    {
        List<T> GetAll();
        T GetById(TId id);
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(TId id);
    }
}
