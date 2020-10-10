using Farmino.Service.Service.Interfaces;

namespace Farmino.Service.Service.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
