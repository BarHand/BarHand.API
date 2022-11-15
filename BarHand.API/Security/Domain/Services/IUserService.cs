using BarHand.API.Security.Domain.Models;
using BarHand.API.Security.Domain.Services.Communication;

namespace BarHand.API.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(long id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(long id, UpdateRequest request);
    Task DeleteAsync(long id);
}