using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiParser.Infrastructure.Services;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IContextService _contextService;
        public UserController(UserService userService, IContextService contextService)
        {
            _userService = userService;
            _contextService = contextService;
        }

        [HttpGet]
        [Authorize]
        public UserModel? GetUser()
        {
            return _contextService.CurrentUser;
        }

        [HttpPost("auth")]
        public async Task<string> Authorize([FromBody] AuthModel authorizeDto) => await _userService.Authorize(authorizeDto);

        [HttpPost("registration")]
        public async Task Registration([FromBody] RegistrationModel registration) => await _userService.Registration(registration);
    }

}
