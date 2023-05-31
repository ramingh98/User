using Common.Query;
using Shop.Domain.Users;

namespace Shop.Query.Users.DTOs
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
