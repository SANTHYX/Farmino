using System;
using System.Net.Http;

namespace Farmino.Service.Service.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
