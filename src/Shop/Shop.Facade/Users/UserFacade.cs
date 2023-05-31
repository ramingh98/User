using Common.Application;
using Common.Domain.ValueObjects;
using MediatR;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetByFilter;
using Shop.Query.Users.GetById;

namespace Shop.Facade.Users
{
    public class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> EditUserAsync(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserDto> GetUserByIdAsync(long id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        public async Task<UserFilterResult> GetUsersByFilterAsync(UserFilterParams filterParams)
        {
            return await _mediator.Send(new GetUsersByFilterQuery(filterParams));
        }

        public async Task<OperationResult> RegisterUserAsync(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
