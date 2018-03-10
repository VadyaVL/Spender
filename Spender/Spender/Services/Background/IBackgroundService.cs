using Spender.Core;

namespace Spender.Services
{
    public interface IBackgroundService
    {
        void Start(NotificationData notificationData);

        void Update(NotificationData notificationData);

        void Stop(); 
    }
}