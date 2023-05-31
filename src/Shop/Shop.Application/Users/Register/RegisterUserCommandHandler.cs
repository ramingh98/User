using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.Users;
using Shop.Infrastructure.Persistent;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly AppDbContext _context;

        public RegisterUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (_context.Users.Any(q => q.PhoneNumber == request.PhoneNumber))
            {
                return OperationResult.Error("شماره موبایل قبلا ثبت شده است");
            }
            if (_context.Users.Any(q => q.Email == request.Email))
            {
                return OperationResult.Error("ایمیل قبلا ثبت شده است");
            }
            if (DateTime.Now.Year - request.BirthDate.Year < 18)
            {
                return OperationResult.Error("زیر 18 سال نمیتواند ثبت نام کند");
            }

            var password = Sha256Hasher.Hash(request.Password);

            var user = new User()
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = password,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate,
                City = request.City,
                NationalCode = request.NationalCode,
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}
