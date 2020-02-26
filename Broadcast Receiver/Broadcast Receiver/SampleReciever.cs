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

namespace Broadcast_Receiver
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class SampleReciever : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            {
                string value = intent.GetStringExtra("key");

                string toastStr = string.Format("Received intent! – Intent Action:{ 0}, Value ={ 1}",intent.Action, value);

                Toast.MakeText(context, toastStr,
                            ToastLength.Long).Show();
            }
        }
    }
}