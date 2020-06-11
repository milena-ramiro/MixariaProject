using ProjectMixaria.Util;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMixaria
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                Xamarin.Forms.DependencyService.Get<IAndroidHideStatusBar>().HideStatusBar(true);
            }

            MainPage = new NavigationPage(new View.InicioPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
