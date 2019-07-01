namespace wkn.Evet.Abstractions.Core
{
    public interface IQueryResult<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        T Data { get; set; }
        
    }
}