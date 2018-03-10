using Android.App;
using Android.Content;
using Android.OS;
using Spender.Converters;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spender.Droid.Services
{
    [Service(Exported = true, Name = "com.vadym.spender.PeriodicService")]
    public class PeriodicService : Service
    {
        public static string Title { get; set; }

        public static DateTime StartDateTime { get; set; }

        // A notification requires an id that is unique to the application.
        public const int NOTIFICATION_ID = 9000;

        #region Fields

        private bool _isRuning;

        #endregion

        #region Fields

        private Notification.Builder _notificationBuilder;

        private TimeSpanToStringConverter _timeSpanToStringConverter;

        #endregion

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            this._isRuning = false;

            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Cancel(NOTIFICATION_ID);
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (intent.Action != null && intent.Action.Equals("STOP_TIMER"))
            {
                // Open app and
                MessagingCenter.Send<object>(this, "StopTime");
            }
            else
            {
                this._timeSpanToStringConverter = new TimeSpanToStringConverter();

                this._isRuning = true;

                // Work has finished, now dispatch anotification to let the user know.
                this._notificationBuilder = new Notification.Builder(this)
                    .SetSmallIcon(Resource.Drawable.icon)
                    .SetContentTitle(Title)
                    .SetContentText(this._timeSpanToStringConverter.Convert(DateTime.UtcNow.Subtract(StartDateTime), null, null, null).ToString())
                    .SetOngoing(true)
                    //.SetContentIntent(PendingIntent.GetActivity(Forms.Context, 0, intent, PendingIntentFlags.UpdateCurrent));
                    .AddAction(StopTimerAction());

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);

                Task.Run(async () => await Update());
                notificationManager.Notify(NOTIFICATION_ID, this._notificationBuilder.Build());
            }

            return StartCommandResult.NotSticky;
        }

        private async Task Update()
        {
            do
            {
                await Task.Delay(1000);
                MessagingCenter.Send<object, TimeSpan>(this, "UpdateTime", DateTime.UtcNow.Subtract(StartDateTime));
                this.UpdateNotification();
            } while (this._isRuning);
        }

        private void UpdateNotification()
        {
            var notification = this._notificationBuilder.SetContentText(this._timeSpanToStringConverter.Convert(DateTime.UtcNow.Subtract(StartDateTime), null, null, null).ToString()).Build();
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(NOTIFICATION_ID, notification);
        }

        //      /// <summary>
        ///// Builds a PendingIntent that will display the main activity of the app. This is used when the 
        ///// user taps on the notification; it will take them to the main activity of the app.
        ///// </summary>
        ///// <returns>The content intent.</returns>
        //PendingIntent BuildIntentToShowMainActivity()
        //      {
        //          var notificationIntent = new Intent(this, typeof(MainActivity));
        //          notificationIntent.SetAction("ServicesDemo3.action.MAIN_ACTIVITY");
        //          notificationIntent.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTask);
        //          notificationIntent.PutExtra("has_service_been_started", true);

        //          var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, PendingIntentFlags.UpdateCurrent);
        //          return pendingIntent;
        //      }

        /// <summary>
        /// Builds a Notification.Action that will instruct the service to restart the timer.
        /// </summary>
        /// <returns>The restart timer action.</returns>
        private Notification.Action StopTimerAction()
        {
            var restartTimerIntent = new Intent(this, GetType());
            restartTimerIntent.SetAction("STOP_TIMER");
            var restartTimerPendingIntent = PendingIntent.GetService(this, 0, restartTimerIntent, 0);

            var builder = new Notification.Action.Builder(Resource.Drawable.ic_action_stop,
                                              GetText(Resource.String.stop),
                                              restartTimerPendingIntent);

            return builder.Build();
        }

        private void Stop()
        {
            MessagingCenter.Send<object, TimeSpan>(this, "UpdateTime", DateTime.UtcNow.Subtract(StartDateTime));
        }
    }
}