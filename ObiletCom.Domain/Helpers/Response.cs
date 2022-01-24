using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Domain.Helpers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public Response() { }
        public Response(bool isSuccess, string message, Exception exception, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Exception = exception;
            Data = data;
        }
        public Response(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
        public Response(bool isSuccess, T data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public Response(bool isSuccess, string message, Exception exception)
        {
            IsSuccess = isSuccess;
            Message = message;
            Exception = exception;
        }
        public Response(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public Response(Exception exception)
        {
            Exception = exception;
        }
        public Response(Exception exception, string message)
        {
            Exception = exception;
            Message = message;
        }
        public Response(string message)
        {
            Message = message;
        }
    }
}
