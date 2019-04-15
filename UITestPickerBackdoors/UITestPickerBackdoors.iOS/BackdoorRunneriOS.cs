using System;
namespace UITestPickerBackdoors.iOS
{
    /// <summary>
    /// Implementation of the IBackdoorRunner for iOS. This allows us to run the backdoors from within the app, without running a UI Test.
    /// This allows us to debug the Backdoor methods, which is otherwise difficult (impossible?) when running a UI Test.
    /// </summary>
    public class BackdoorRunneriOS : IBackdoorRunner
    {
        public void SetFormsDatePickerValue(string automationId, DateTime value)
        {
            UITestBackdoorMethods.SetFormsDatePickerValue(automationId, value);
        }

        public void SetFormsPickerIndex(string automationId, int value)
        {
            UITestBackdoorMethods.SetFormsPickerIndex(automationId, value);
        }

        public void SetFormsPickerValue(string automationId, string value)
        {
            UITestBackdoorMethods.SetFormsPickerValue(automationId, value);
        }
    }
}
