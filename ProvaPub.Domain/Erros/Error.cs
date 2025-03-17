using ProvaPub.Domain.Enums;

namespace ProvaPub.Domain.Erros;
public class Error
{
    public Error(EErrorType errorType, string message)
    {
        ErrorType = errorType;
        Message = message;
    }

    public EErrorType ErrorType { get; }
    public string Message { get; }
}
