using System.Text.Json.Serialization;

namespace MiniECommerce.Application
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Error { get; set; }

        public string Message { get; set; }

        //static Factory Method Dessing Pattern.
        public static CustomResponseDto<T> Success(int statusCode, T data, string message)
        {
            return new CustomResponseDto<T>() { Data = data, StatusCode = statusCode, Message = message };
        }

        public static CustomResponseDto<T> Success(int statusCode, string message)
        {
            return new CustomResponseDto<T>() { StatusCode = statusCode, Message = message };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors, string message)
        {
            return new CustomResponseDto<T>() { StatusCode = statusCode, Error = errors, Message = message };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error, string message)
        {
            return new CustomResponseDto<T>() { StatusCode = statusCode, Error = new List<string> { error }, Message = message };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string message)
        {
            return new CustomResponseDto<T>() { StatusCode = statusCode, Message = message };
        }
    }
}
