using BarHand.API.Security.Domain.Models;

namespace BarHand.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(long id);
    Task<User> FindByNameAsync(string name);
    bool ExistsByName(string name);
    User FindById(long id);
    void Update(User user);
    void Remove(User user);
}