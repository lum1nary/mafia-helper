using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace MafiaHelper.Android.View
{
    [Activity(Label = "Mafia Helper", Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource 
            SetContentView(Resource.Layout.Main);
        }
    }
}