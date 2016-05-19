using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Widget;
using System;

namespace LocalNotificationApp
{
    [Activity(Label = "Local Notification App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get { return Resource.Layout.main; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

            var btnShowNotification = FindViewById<Button>(Resource.Id.btnShowNotification);

            btnShowNotification.Click += BtnShowNotification_Click;
        }

        private void BtnShowNotification_Click(object sender, EventArgs e)
        {
            //Second Activity
            var intent = new Intent(this, typeof(SecondActivity));
            intent.PutExtra("Message", "Hello from First Activity");

            var taskStackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            taskStackBuilder.AddNextIntent(intent);

            const int pendingIntentId = 0;
            PendingIntent pendingIntent = taskStackBuilder.GetPendingIntent(pendingIntentId,(int)PendingIntentFlags.OneShot);


            // Instantiate the builder and set the notification elements
            Notification.Builder builder = new Notification.Builder(this)
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Local Notification")
                .SetContentText("This is local notification")
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetDefaults(NotificationDefaults.Sound)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

            // Build the notification
            Notification notification = builder.Build();

            // Get the notification manager
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification
            notificationManager.Notify(0, notification);
        }
    }
}

