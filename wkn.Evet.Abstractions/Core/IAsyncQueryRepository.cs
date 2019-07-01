using System.Collections.Generic;
using System.Threading.Tasks;

namespace wkn.Evet.Abstractions.Core
{
    public interface IAsyncQueryRepository<T>
    {
        // this repo only performs query operations
        // get a single Entity
        Task<IQueryResult<T>> FindObjectAsync(object id);
        Task<IQueryResult<IEnumerable<T>>> FindObjectAsync(ICriteria criteria);
             
    }
}