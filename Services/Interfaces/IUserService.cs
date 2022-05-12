using Task.API.ViewModel.Requests;
using Task.API.ViewModel.Responses;

namespace Task.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);
        Task<LogoutResponse> LogoutAsync(int userId);
    }
}
