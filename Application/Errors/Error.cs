namespace Application.Errors;

public sealed class Error
{
    public Error(string errorCode, string message)
    {
        ErrorCode = errorCode;
        Message = message;
    }

    public string ErrorCode { get; set; }
    public string Message { get; set; }

}
