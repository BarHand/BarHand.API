using BarHand.API.Notifications.Domain.Models;
using BarHand.API.Notifications.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using BarHand.API.Suppliers.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace BarHand.API.Notifications.Persistence.Repositories;

    public class NotificationRepository : BaseRepository, INotificationRepository 
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public async Task<IEnumerable<Notification>> FindByTypeIdAsync(long id, string type)
        {
            return await _context.Notifications
                .Where(p => p.TypeId == id && p.Type == type)
                .ToListAsync();
        }


    public async Task<Notification> FindByIdAsync(long id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public void Update(Notification notification)
        {
            _context.Notifications.Update(notification);
        }

        public void Remove(Notification notification)
        {
            _context.Notifications.Remove(notification);
        }


    }

