namespace MTAPI.Models
{
    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int? Count { get; set; }
    }
}
