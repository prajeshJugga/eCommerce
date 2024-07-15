using eCommerceDatabase.DTOs;
using System.ComponentModel.DataAnnotations;

namespace eCommerceDatabase.Models
{
    /// <summary>
    /// Assume all customers
    /// </summary>
    public class Customer
    {
        public Customer()
        {
        }
        public Customer(CustomerDTO customer)
        {
            Id = customer.Id;
            Username = customer.Username;
            Name = customer.Name;
            Surname = customer.Surname;
            Address = customer.Address;
            Email = customer.Email;
            Phone = customer.Phone;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
