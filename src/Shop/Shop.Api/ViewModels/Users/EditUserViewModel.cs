using Common.Application.Validation.CustomValidation.IFormFile;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Users
{
    public class EditUserViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
