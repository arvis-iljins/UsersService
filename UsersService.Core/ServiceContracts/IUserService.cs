using UsersService.Core.DTO;

namespace UsersService.Core.ServiceContracts
{
    /// <summary>
    /// Define the contract for user-related services in the UsersService application.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>The authentication response containing the user's session information.</returns>
        Task<AuthenticationResponse?> Login(LoginRequest request);

        /// <summary>
        /// Registers a new user with the provided details.
        /// </summary>
        /// <param name="request">The registration request containing user details.</param>
        /// <returns>The authentication response containing the registered user's session information.</returns>
        Task<AuthenticationResponse?> RegisterUser(RegisterRequest request);

        /// <summary> Retrieves a user by their unique identifier.
        /// </summary> <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>The user matching the provided identifier, or null if no match is found.</returns>
        Task<User?> GetUserById(Guid id);
    }
}
