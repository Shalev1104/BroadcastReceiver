using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace Broadcast_Receiver
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SampleReciever reciever;
        private Button broadcast;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            reciever = new SampleReciever();
            SetViews();
        }
        public void SetViews()
        {
            broadcast = FindViewById<Button>(Resource.Id.btnBroadcastReciever);
            broadcast.Click += Broadcast_Click;
        }

        private void Broadcast_Click(object sender, System.EventArgs e)
        {
            Intent message = new Intent("com.xamarin.example.TEST");
            message.PutExtra("key", "value");
            SendBroadcast(message);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(reciever, new Android.Content.IntentFilter("com.xamarin.example.TEST"));
        }
        protected override void OnPause()
        {
            UnregisterReceiver(reciever);
            base.OnPause();
        }
    }
}