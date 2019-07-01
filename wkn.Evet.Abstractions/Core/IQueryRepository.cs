using System.Collections.Generic;

namespace wkn.Evet.Abstractions.Core
{
    public interface IQueryRepository<T>
    {
        // this repo only performs query operations
        // get a single Entity
        IQueryResult<T> FindObject(object id);
        IQueryResult<IEnumerable<T>> FindObject(ICriteria criteria);
        bool IsFound(T obj);
    }
}