using Common.Query;

namespace Shop.Query.Users.DTOs
{
    public class UserFilterData : BaseDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string City { get; set; }
        public DateTime BirthDate{ get; set; }
    }
}
