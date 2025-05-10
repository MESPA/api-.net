using UserManagementAPI.Application.DTOs;

namespace UserManagementAPI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(UserRegistrationDto registrationDto);
        Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto);
        string GenerateJwtToken(UserDto user);
    }
}
