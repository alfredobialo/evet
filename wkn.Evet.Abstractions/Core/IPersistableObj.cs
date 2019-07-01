namespace wkn.Evet.Abstractions.Core
{
    public interface IPersistableObj<T> where T : IPersistableObj<T>
    {
        object Id { get; set; }
        dynamic Tag { get; set; }
        IRepository<T> DataSource { get; }
    }

   
}