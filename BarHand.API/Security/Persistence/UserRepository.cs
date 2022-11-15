using BarHand.API.Security.Domain.Models;
using BarHand.API.Security.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Security.Persistence.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(long id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByUserNameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x=>x.Username==username);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }

    public User FindById(long id)
    {
        return _context.Users.Find(id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
    
}