using UsersService.Core.DTO;
using UsersService.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace UsersService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary> <param name="request">The login request containing user credentials.</param>
        /// <returns>The authentication response containing the user's session information.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.Login(request);
            var isUserLoggedIn = user is not null && user.Success;
            if (!isUserLoggedIn)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(user);
        }

        /// <summary> Registers a new user with the provided details.
        /// </summary> <param name="request">The registration request containing user details.</param>
        /// <returns>The authentication response containing the registered user's session information.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var user = await _userService.RegisterUser(request);
            var isUserRegistered = user is not null && user.Success;
            if (!isUserRegistered)
            {
                return BadRequest("Failed to register user.");
            }

            return Ok(user);
        }
    }
}
