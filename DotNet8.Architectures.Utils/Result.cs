using DotNet8.Architectures.Utils.Enums;

namespace DotNet8.Architectures.Utils
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public EnumStatusCode StatusCode { get; set; }

        public static Result<T> Success(string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
            => new()
            { Message = message, StatusCode = statusCode, IsSuccess = true };

        public static Result<T> Success(T data, string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
            => new() { Data = data, Message = message, StatusCode = statusCode, IsSuccess = true };

        public static Result<T> Failure(string message = "Fail.", EnumStatusCode statusCode = EnumStatusCode.BadRequest)
            => new() { Message = message, StatusCode = statusCode, IsSuccess = false };
    }
}
