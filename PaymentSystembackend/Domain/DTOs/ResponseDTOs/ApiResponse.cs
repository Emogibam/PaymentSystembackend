using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ResponseDTOs
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(int statusCode, string status, string message, T data = default, List<string> errors = null)
        {
            StatusCode = statusCode;
            Status = status;
            Message = message;
            Data = data;
            Errors = errors ?? new List<string>();
        }

        public static ApiResponse<T> Success(int statusCode, string message, T data)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Status = "Success",
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Failure(int statusCode, string message, List<string> errors)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Status = "Failure",
                Message = message,
                Errors = errors
            };
        }

        public static ApiResponse<T> Error(int statusCode, string message)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Status = "Error",
                Message = message
            };
        }
    }
}
