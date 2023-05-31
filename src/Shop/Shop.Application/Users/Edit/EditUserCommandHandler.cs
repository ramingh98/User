using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application._Utilities;
using Shop.Infrastructure.Persistent;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly AppDbContext _context;

        public EditUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(q => q.Id == request.Id);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.BirthDate = request.BirthDate;
            user.PhoneNumber = request.PhoneNumber;
            user.NationalCode = request.NationalCode;
            user.City = request.City;
            await _context.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}
