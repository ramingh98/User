using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.Edit;
using Shop.Facade.Users;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPut]
        public async Task<ApiResult> EditUser([FromForm] EditUserViewModel viewModel)
        {
            var result = await _userFacade.EditUserAsync(new EditUserCommand
            {
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                Id = viewModel.Id,
                BirthDate = viewModel.BirthDate,
                NationalCode = viewModel.NationalCode,
                PhoneNumber = viewModel.PhoneNumber
            });
            return CommandResult(result);
        }

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
        {
            var result = await _userFacade.GetUsersByFilterAsync(filterParams);
            return QueryResult(result);
        }

        [HttpGet("Current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await _userFacade.GetUserByIdAsync(User.GetUserId());
            return QueryResult(result);
        }

        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto>> GetById(long userId)
        {
            var result = await _userFacade.GetUserByIdAsync(userId);
            return QueryResult(result);
        }
    }
}
