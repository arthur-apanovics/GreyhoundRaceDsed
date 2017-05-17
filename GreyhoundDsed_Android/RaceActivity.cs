using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace GreyhoundDsed_Android
{
    [Activity(Label = "Race")]
    public class RaceActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            //Remove notification bar
            //GetWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

            SetContentView(GreyhoundDsed_Android.Resource.Layout.Race);

            TranslateAnimation moveAnim = new TranslateAnimation(0, 350, 15, 15);
            moveAnim.RepeatCount = int.MaxValue;
            moveAnim.Duration = 2000;

            ImageView wave = FindViewById<ImageView>(GreyhoundDsed_Android.Resource.Id.imgWater);
            wave.StartAnimation(moveAnim);
        }
    }
}