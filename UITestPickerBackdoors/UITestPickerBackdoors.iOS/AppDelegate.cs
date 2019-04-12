using System;
using Foundation;
using UIKit;

namespace UITestPickerBackdoors.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            // Start Calabash if we've got UITest enabled
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

#if ENABLE_TEST_CLOUD
        [Export("selectPickerValue:")] // notice the colon at the end of the method name
        public NSString SelectPickerValue(NSString parameters)
        {
            var idAndValueAsString = (string)parameters;

            var myParams = idAndValueAsString.Split('|');
            if (myParams.Length != 2)
            {
                throw new Exception($"SelectPickerValue: Could not parse '{parameters}' into an Id and Value");
            }

            string returnValue = UITestBackdoorMethods.SelectPickerValue(myParams[0], myParams[1]);
            return new NSString(returnValue);

        }

        [Export("selectFirstPickerValue:")] // notice the colon at the end of the method name
        public NSString SelectFirstPickerValue(NSString automationId)
        {
            string returnValue = UITestBackdoorMethods.SelectFirstPickerValue(automationId);
            return new NSString(returnValue);

        }

        [Export("setDatePickerValue:")] // notice the colon at the end of the method name
        public NSString SetDatePickerValue(NSString parameters)
        {
            var idAndValueAsString = (string)parameters;

            var myParams = idAndValueAsString.Split('|');
            if (myParams.Length != 2)
            {
                throw new Exception($"SetDatePickerValue: Could not parse '{parameters}' into an Id and Value");
            }

            DateTime value = DateTime.Parse(myParams[1]);
            string returnValue = UITestBackdoorMethods.SetDatePickerValue(myParams[0], value);

            return new NSString(returnValue);

        }

#endif
    }
}
