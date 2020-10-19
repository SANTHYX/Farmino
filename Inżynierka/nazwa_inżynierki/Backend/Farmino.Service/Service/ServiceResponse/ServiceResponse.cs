namespace Farmino.Service.Service.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public T Data { get; set; }
    }
}
