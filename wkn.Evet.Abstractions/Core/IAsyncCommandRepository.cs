using System.Threading.Tasks;

namespace wkn.Evet.Abstractions.Core
{
    public interface IAsyncCommandRepository<T>
    {
        // this repo only performs query operations
        // get a single Entity
        Task<ICommandResult> CreateObjectAsync(T obj);
        Task<ICommandResult> DeleteObjectAsync(T obj);
        Task<ICommandResult> UpdateObjectAsync(T obj, ICriteria criteria);
        Task<ICommandResult> UpdateObjectAsync(T obj);
                  
    }
}