using System;
using System.Threading.Tasks;

using AppKit;
using Foundation;
using Plugin.InAppBilling;

namespace iap
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Do any additional setup after loading the view.
        }

        async partial void Purchase(Foundation.NSObject sender)
        {
            await Purchase();
        }

        private async Task Purchase()
        {
            try
            {
                var connected = await CrossInAppBilling.Current.ConnectAsync();
                //try to purchase item
                var purchase = await CrossInAppBilling.Current.PurchaseAsync("mysku", ItemType.InAppPurchase, "apppayload");
                if (purchase == null)
                {
                    //Not purchased
                }
                else
                {
                    //Purchased!
                }
            }
            catch (Exception ex)
            {
                //Something went wrong :()
            }
            finally
            {
                //busy = false;
                await CrossInAppBilling.Current.DisconnectAsync();
}
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
