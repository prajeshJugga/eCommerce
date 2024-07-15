namespace eCommerceApi.Responses
{
    public class Response<T> where T : class
    {
        public Response(T data) 
        { 
            Data = data;
        }
        public T Data { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
