using eCommerceDatabase.Models;

namespace eCommerceDatabase.DTOs
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
            
        }
        public CustomerDTO(Customer customer)
        {
            Id = customer.Id;
            Username = customer.Username;
            Name = customer.Name;
            Surname = customer.Surname;
            Address = customer.Address;
            Email = customer.Email;
            Phone = customer.Phone;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
