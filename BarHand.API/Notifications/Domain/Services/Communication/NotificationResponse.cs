using BarHand.API.Notifications.Domain.Models;
using BarHand.API.Shared.Domain.Services.Communication;
using BarHand.API.Suppliers.Domain.Models;

namespace BarHand.API.Notifications.Domain.Services.Communication
{
    public class NotificationResponse : BaseResponse<Notification>
    {

        public NotificationResponse(string message) : base(message)
        {
        }

        public NotificationResponse(Notification resource) : base(resource)
        {
        }
    }
}
