using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly AppDbContext _context;

        public GetUserByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(q => q.Id == request.Id);
            if (user == null)
            {
                return null;
            }
            return new UserDto
            {
                CreationDate = user.CreationDate,
                Email = user.Email,
                FullName = user.FullName,
                Id = request.Id,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                NationalCode = user.NationalCode
            };
        }
    }
}
