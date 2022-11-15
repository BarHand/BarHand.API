using BarHand.API.Security.Domain.Models;

namespace BarHand.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(long id);
    Task<User> FindByUserNameAsync(string username);
    bool ExistsByUsername(string username);
    User FindById(long id);
    void Update(User user);
    void Remove(User user);
}