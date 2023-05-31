using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByFilter
{
    public class GetUsersByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetUsersByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
