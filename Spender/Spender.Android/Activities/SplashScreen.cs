using Android.App;
using Android.OS;

namespace Spender.Droid
{
    // Use splash via theme or SetContentView (find solution)
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.Splash);

            this.StartActivity(typeof(MainActivity));
        }
    }
}