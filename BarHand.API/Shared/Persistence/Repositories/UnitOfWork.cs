using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;

namespace BarHand.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();//save all changes in to context database
    }
}