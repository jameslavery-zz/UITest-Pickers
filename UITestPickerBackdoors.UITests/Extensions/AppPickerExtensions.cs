using Xamarin.UITest;

namespace UITestPickerBackdoors.UITests.Extensions
{
    public static class AppPickerExtensions
    {
        public static void SelectPickerValue(this IApp app, Platform platform, string automationId, string value)
        {
            if (platform == Platform.iOS)
            {
                // construct a parameter of the automationId of the Picker and the value to set
                string parameter = $"{automationId}|{value}";
                app.Invoke("selectPickerValue:", parameter);
            }
        }
    }
}
