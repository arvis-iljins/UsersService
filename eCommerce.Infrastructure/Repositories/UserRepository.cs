using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository(DapperDbContext dbContext) : IUserRepository
    {
        private readonly DapperDbContext _dbContext = dbContext;

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.Id = Guid.NewGuid();
            string sql =
                @"
                INSERT INTO public.""User"" (""UserId"", ""Email"", ""Password"", ""PersonName"", ""Gender"")
                VALUES (@Id, @Email, @Password, @PersonName, @Gender);
            ";
            await _dbContext.Connection.ExecuteAsync(sql, user);

            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(
            string? email,
            string? password
        )
        {
            string sql =
                @"
                SELECT * FROM public.""User""
                WHERE ""Email"" = @email AND ""Password"" = @password;
            ";
            var user = await _dbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(
                sql,
                new { email, password }
            );
            return user;
        }

        public async Task<ApplicationUser?> GetUserById(Guid id)
        {
            string sql =
                @"
                SELECT * FROM public.""User""
                WHERE ""UserId"" = @id;
            ";
            var user = await _dbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(
                sql,
                new { id }
            );
            return user;
        }
    }
}
