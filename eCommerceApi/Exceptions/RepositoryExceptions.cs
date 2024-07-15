namespace eCommerceApi.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
        {
            
        }
        public CustomerNotFoundException(string message) : base(message) { }

        public CustomerNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException()
        {

        }
        public BasketNotFoundException(string message) : base(message) { }

        public BasketNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class SpecialNotFoundException : Exception
    {
        public SpecialNotFoundException()
        {

        }
        public SpecialNotFoundException(string message) : base(message) { }

        public SpecialNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException()
        {

        }
        public ProductNotFoundException(string message) : base(message) { }

        public ProductNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
