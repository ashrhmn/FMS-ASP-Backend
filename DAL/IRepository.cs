using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T, TId>
    {
        List<T> GetAll();
        T GetById(TId id);
        bool Add(T obj);
        bool Update(TId id,T obj);
        bool Delete(TId id);
    }
}
