using UsersService.Core.Enums;

namespace UsersService.Core.DTO
{
    public record RegisterRequest(
        string? Email,
        string? Password,
        string? PersonName,
        GenderOptions Gender
    );
}
