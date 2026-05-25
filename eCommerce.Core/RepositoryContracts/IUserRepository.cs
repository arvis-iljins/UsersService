using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">The user details to register.</param>
        /// <returns>The registered user.</returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary> Retrieves a user by their email and password for authentication purposes.
        /// </summary> <param name="email">The email of the user to retrieve.</param>
        /// <param name="password">The password of the user to retrieve.</param>
        /// <returns>The user matching the provided email and password, or null if no match is found.</returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

        /// <summary> Get user by id.
        /// </summary> <param name="id">The id of the user to retrieve.</param>
        /// <returns>The user matching the provided id, or null if no match is found.</returns>
        Task<ApplicationUser?> GetUserById(Guid id);
    }
}
