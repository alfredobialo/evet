namespace wkn.Evet.Abstractions.Core
{
    public interface IRepository<T> where T : IPersistableObj<T>
    { 
        ICommandRepository<T> CommandRepository { get;  }
        IQueryRepository<T> QueryRepository { get; }
    }
}