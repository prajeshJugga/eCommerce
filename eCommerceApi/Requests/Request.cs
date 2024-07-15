namespace eCommerceApi.Requests
{
    public class Request<T> where T : class
    {
        public Request(T data) 
        { 
            Data = data;
        }
        public T Data { get; set; }
    }
}
