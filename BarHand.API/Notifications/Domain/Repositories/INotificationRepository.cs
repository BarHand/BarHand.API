using BarHand.API.Notifications.Domain.Models;

namespace BarHand.API.Notifications.Domain.Repositories;

    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task AddAsync(Notification notification);
        Task<Notification> FindByIdAsync(long id);
    //Task<Notification> FindByUserIdAsync(long userId);

    Task<IEnumerable<Notification>> FindByTypeIdAsync(long id, string type);
        void Update(Notification notification);
        void Remove(Notification notification);
    }

