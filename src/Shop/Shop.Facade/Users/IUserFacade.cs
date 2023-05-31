using Common.Application;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Query.Users.DTOs;

namespace Shop.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUserAsync(RegisterUserCommand command);
        Task<OperationResult> EditUserAsync(EditUserCommand command);
        Task<UserDto> GetUserByIdAsync(long id);
        Task<UserFilterResult> GetUsersByFilterAsync(UserFilterParams filterParams);
    }
}
