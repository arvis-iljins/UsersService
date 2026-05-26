using AutoMapper;
using UsersService.Core.DTO;
using UsersService.Core.Entities;
using UsersService.Core.RepositoryContracts;
using UsersService.Core.ServiceContracts;

namespace UsersService.Core.Services
{
    internal class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<User?> GetUserById(Guid id)
        {
            var userEntity = await _userRepository.GetUserById(id);
            if (userEntity is null)
            {
                return null;
            }
            var user = _mapper.Map<User>(userEntity);

            return user;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest request)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(
                request.Email,
                request.Password
            );

            if (user is null)
            {
                return null;
            }

            var userResponse = _mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true,
                Token = "dummy-token-for-now",
            };

            return userResponse;
        }

        public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            ApplicationUser? registerResponse = await _userRepository.AddUser(user);

            if (registerResponse is null)
            {
                return null;
            }

            var userResponse = _mapper.Map<AuthenticationResponse>(registerResponse) with
            {
                Success = true,
                Token = "dummy-token-for-now",
            };
            return userResponse;
        }
    }
}
