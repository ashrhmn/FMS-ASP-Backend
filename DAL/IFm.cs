using System.Collections.Generic;

namespace DAL
{
    public interface IFm<T, TId>
    {
        List<T> GetAll(TId id);
    }
}
