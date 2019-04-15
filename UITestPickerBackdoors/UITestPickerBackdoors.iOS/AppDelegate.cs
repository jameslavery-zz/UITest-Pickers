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
        [Export("setFormsPickerValue:")] // notice the colon at the end of the method name
        public NSString SetFormsPickerValue(NSString parameters)
        {
            var idAndValueAsString = (string)parameters;

            var myParams = idAndValueAsString.Split('|');
            if (myParams.Length != 2)
            {
                throw new Exception($"SelectPickerValue: Could not parse '{parameters}' into an Id and Value");
            }

            string returnValue = UITestBackdoorMethods.SetFormsPickerValue(myParams[0], myParams[1]);
            return new NSString(returnValue);

        }

        [Export("SetFormsFirstPickerValue:")] // notice the colon at the end of the method name
        public NSString SetFormsFirstPickerValue(NSString automationId)
        {
            string returnValue = UITestBackdoorMethods.SetFormsFirstPickerValue(automationId);
            return new NSString(returnValue);

        }

        [Export("setFormsDatePickerValue:")] // notice the colon at the end of the method name
        public NSString SetFormsDatePickerValue(NSString parameters)
        {
            var idAndValueAsString = (string)parameters;

            var myParams = idAndValueAsString.Split('|');
            if (myParams.Length != 2)
            {
                throw new Exception($"SetDatePickerValue: Could not parse '{parameters}' into an Id and Value");
            }

            // Parse the parameter from a string to a DateTime
            DateTime value = DateTime.Parse(myParams[1]);
            string returnValue = UITestBackdoorMethods.SetFormsDatePickerValue(myParams[0], value);

            return new NSString(returnValue);

        }

#endif
    }
}
