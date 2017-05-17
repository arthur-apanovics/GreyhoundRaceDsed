using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace GreyhoundDsed_Android
{
    [Activity(Label = "GreyhoundDsed_Android", MainLauncher = true, Icon = "@drawable/turtle")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView (GreyhoundDsed_Android.Resource.Layout.Main);

            Button btnStart = FindViewById<Button>(GreyhoundDsed_Android.Resource.Id.btnStart);
            btnStart.Click += delegate
            {
                StartActivity(typeof(RaceActivity)); 
            };
        }
    }
}

