using System;
using System.Net.Http;

namespace Farmino.Service.Service.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; } = new HttpResponseMessage().IsSuccessStatusCode;
        public string Message { get; set; } = new Exception().Message;
        public T Data { get; set; }
    }
}
