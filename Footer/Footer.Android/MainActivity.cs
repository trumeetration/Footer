using System;

using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Runtime;
using Android.OS;
using Android.Widget;

namespace Footer.Droid
{
    [Activity(Label = "Footer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.SetStatusBarColor(Color.ParseColor("#3EC1D3"));
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Forms.DependencyService.Register<StepCounter>();
            if (Application.Context.PackageManager.HasSystemFeature(Android.Content.PM.PackageManager
                .FeatureSensorStepCounter) &&
                       Application.Context.PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureSensorStepDetector))
                Toast.MakeText(Application.Context, "SENSOR WORKS", ToastLength.Long).Show();
            else
                Toast.MakeText(Application.Context, "ALARMAARLASJSSADSAD", ToastLength.Long).Show();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}