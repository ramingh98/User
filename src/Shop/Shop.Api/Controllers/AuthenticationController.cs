using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Authentication;
using Shop.Application.Users.Register;
using Shop.Facade.Users;
using UAParser;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public AuthenticationController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost("Register")]
        public async Task<ApiResult> Register(RegisterViewModel viewModel)
        {
            var result = await _userFacade.RegisterUserAsync(new RegisterUserCommand()
            {
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                Password = viewModel.Password,
                PhoneNumber = viewModel.PhoneNumber,
                NationalCode = viewModel.NationalCode,
                BirthDate = viewModel.BirthDate,
                City = viewModel.City
            });
            return CommandResult(result);
        }
    }
}
