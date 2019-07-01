namespace wkn.Evet.Abstractions.Core
{
    public interface ICommandRepository<T>
    {
        // this repo only performs query operations
        // get a single Entity
        ICommandResult CreateObject(T obj);
        ICommandResult DeleteObject(T obj);
        ICommandResult UpdateObject(T obj, ICriteria criteria);
        ICommandResult UpdateObject(T obj);
             
    }
}