using ProvaPub.Domain.Erros;
using System.Text.Json.Serialization;

namespace ProvaPub.Domain.Results;
public class Result<T>
{
    private Result(T value)
    {
        Value = value;
        Error = null;
    }

    private Result(Error error)
    {
        Error = error;
        Value = default;
    }

    [JsonPropertyName("value")]
    public T? Value { get; }  

    [JsonPropertyName("error")]
    public Error? Error { get; }
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess => Error == null;

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(error);

    public TResult Map<TResult>(
        Func<Result<T>, TResult> onSuccess,
        Func<Result<T>, TResult> onFailure)
    {
        return IsSuccess ? onSuccess(this) : onFailure(this);
    }
}
