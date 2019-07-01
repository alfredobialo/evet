namespace wkn.Evet.Abstractions.Core
{
    public interface ICommandResult
    { 
        string Message { get; set; } 
        bool Success { get;  set; }
        dynamic ExtraData { get; set; }
    }
}