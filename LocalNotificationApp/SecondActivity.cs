using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace LocalNotificationApp
{
    [Activity(Label = "Second Activity", Icon = "@drawable/icon",ParentActivity =typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".MainActivity")]
    public class SecondActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get { return Resource.Layout.second; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string message = Intent.GetStringExtra("Message");
            var text = FindViewById<TextView>(Resource.Id.textView1);
            text.Text = message;
        }

    }
}