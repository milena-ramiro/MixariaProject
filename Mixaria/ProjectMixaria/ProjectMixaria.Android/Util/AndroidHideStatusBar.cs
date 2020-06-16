using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjectMixaria.Droid.Util;
using ProjectMixaria.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidHideStatusBar))]
namespace ProjectMixaria.Droid.Util
{
    public class AndroidHideStatusBar : IAndroidHideStatusBar
    {
        WindowManagerFlags _originalFlags;

        public void HideStatusBar(bool hide)
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;

            if (hide)
            {
                _originalFlags = attrs.Flags;
                attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
                activity.Window.Attributes = attrs;
            }
            else
            {
                attrs.Flags = _originalFlags;
                activity.Window.Attributes = attrs;
            }
        }

    }
}