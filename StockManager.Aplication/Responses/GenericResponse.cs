namespace StockManager.Aplication.Responses;

public class GenericResponse<T>
{
    public Func<bool> Success { get; private set; } = () => !Errors.Any();
    public T? Data { get; set; }
    public required string Message { get; set; }
    public static ICollection<string> Errors { get; set; } = [];
}