using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(q => q.FullName).NotNull().WithMessage("نام و نام خانوادگی را وارد نمایید").NotEmpty().WithMessage("نام و نام خانوادگی را وارد نمایید").MaximumLength(50).WithMessage("نام و نام خانوادگی کمتر از 50 کاراکتر باشد");
            RuleFor(q => q.Email).NotNull().WithMessage("ایمیل را وارد نمایید").NotEmpty().WithMessage("ایمیل را وارد نمایید").MaximumLength(100).WithMessage("ایمیل کمتر از 100 کاراکتر باشد");
            RuleFor(q => q.PhoneNumber).NotNull().WithMessage("شماره موبایل را وارد نمایید").NotEmpty().WithMessage("شماره موبایل را وارد نمایید").Length(11).WithMessage("شماره تلفن معتبر وارد نمایید");
            RuleFor(q => q.Password).NotNull().WithMessage("کلمه عبور را وارد نمایید").NotEmpty().WithMessage("کلمه عبور را وارد نمایید").MinimumLength(8).WithMessage("کلمه عبور بیشتر از 7 کاراکتر باشد");
        }
    }
}
