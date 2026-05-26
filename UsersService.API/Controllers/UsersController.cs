using UsersService.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace UsersService.API.Controllers
{
    [Route("[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary> Retrieves a user by their unique identifier.
        /// </summary> <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>The user matching the provided identifier, or null if no match is found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user is null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }
    }
}
