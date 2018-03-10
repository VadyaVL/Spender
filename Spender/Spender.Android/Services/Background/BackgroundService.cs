using Android.Content;
using Spender.Core;
using Spender.Droid.Services;
using Spender.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BackgroundService))]
namespace Spender.Droid.Services
{
    public class BackgroundService : IBackgroundService
    {
        public void Start(NotificationData notificationData)
        {
            var activity = (MainActivity)Forms.Context;

            PeriodicService.Title = notificationData.Title;
            PeriodicService.StartDateTime = notificationData.StartDateTime;
            var intent = new Intent(activity, typeof(PeriodicService));
            activity.StartService(intent);
        }

        public void Stop()
        {
            var activity = (MainActivity)Forms.Context;
            activity.StopService(new Intent(activity, typeof(PeriodicService)));
        }

        public void Update(NotificationData notificationData)
        {
            PeriodicService.Title = notificationData.Title;
            PeriodicService.StartDateTime = notificationData.StartDateTime;
        }
    }
}