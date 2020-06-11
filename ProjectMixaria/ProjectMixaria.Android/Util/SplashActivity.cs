
using Android.App;
using Android.Content.PM;

namespace ProjectMixaria.Droid.Util
{
    [Activity(Label = "Mixaria", Icon = "@drawable/MixariaIcone", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true,
                ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class SplashActivity : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}