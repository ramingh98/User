using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Authentication
{
    public class RegisterViewModel
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
