using BarHand.API.Notifications.Domain.Models;
using BarHand.API.Notifications.Domain.Services.Communication;

namespace BarHand.API.Notifications.Domain.Services;

public interface INotificationService
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task<NotificationResponse> GetByIdAsync(long id);
        Task<IEnumerable<Notification>> ListByTypeIdAsync(long id, string type);
        Task<NotificationResponse> SaveAsync(Notification notification);
        Task<NotificationResponse> UpdateAsync(long supplierId, Notification notification);
        Task<NotificationResponse> DeleteAsync(long id);
    }

