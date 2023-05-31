using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByFilter
{
    public class GetUsersByFilterQueryHandler : IQueryHandler<GetUsersByFilterQuery, UserFilterResult>
    {
        private readonly AppDbContext _context;

        public GetUsersByFilterQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserFilterResult> Handle(GetUsersByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Users.OrderByDescending(q => q.CreationDate).AsQueryable();
            if (request.FilterParams.FullName != null)
            {
                result = result.Where(q => q.FullName.Contains(request.FilterParams.FullName));
            }
            if (request.FilterParams.Email != null)
            {
                result = result.Where(q => q.Email.Contains(request.FilterParams.Email));
            }
            if (request.FilterParams.PhoneNumber != null)
            {
                result = result.Where(q => q.PhoneNumber.Contains(request.FilterParams.PhoneNumber));
            }
            var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
            var data = await result.Skip(skip).Take(request.FilterParams.Take).ToListAsync(cancellationToken);

            var model = new UserFilterResult
            {
                Data = data.Select(q => new UserFilterData
                {
                    CreationDate = q.CreationDate,
                    Email = q.Email,
                    FullName = q.FullName,
                    Id = q.Id,
                    PhoneNumber = q.PhoneNumber,
                    NationalCode = q.NationalCode,
                    BirthDate = q.BirthDate,
                    City = q.City
                }).ToList(),
            };

            model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);
            return model;
        }
    }
}
