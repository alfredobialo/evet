namespace wkn.Evet.Abstractions.Core
{
    public interface ICriteria
    {
        string Query { get; set; }
        object Tag { get; set; }
        bool Paginate { get; set; }
    }
}