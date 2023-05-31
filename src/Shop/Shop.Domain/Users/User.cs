using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Users
{
    public class User : AggregateRoot
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
