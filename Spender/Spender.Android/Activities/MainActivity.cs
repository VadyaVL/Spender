using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.OS;

namespace Spender.Droid
{
    [Activity(Label = "Spender", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            MobileAds.Initialize(ApplicationContext, "ca-app-pub-9279700841245761~7482794385");

            LoadApplication(new App());
        }
    }
}

