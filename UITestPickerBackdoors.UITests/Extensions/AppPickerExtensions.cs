using System;
using Xamarin.UITest;

namespace UITestPickerBackdoors.UITests.Extensions
{
    public static class AppPickerExtensions
    {
        public static void SetFormsPickerIndex(this IApp app, Platform platform, string automationId, string index, bool showPicker = false)
        {
            if (platform == Platform.iOS)
            {
                if (showPicker)
                {
                    app.Tap(e => e.Id(automationId));
                }

                // construct a parameter of the automationId of the Picker and the value to set
                string parameter = $"{automationId}|{index}";
                var result = app.Invoke("setFormsPickerIndex:", parameter);

                if (showPicker)
                {
                    app.Tap(e => e.Text("Done"));
                }
            }
            else
            {
                throw new NotImplementedException("SetFormsPickerIndex not imlemented for Android.");
            }
        }

        public static void SetFormsPickerValue(this IApp app, Platform platform, string automationId, string value, bool showPicker = false)
        {
            if (platform == Platform.iOS)
            {
                if (showPicker)
                {
                    app.Tap(e => e.Id(automationId));
                }

                // construct a parameter of the automationId of the Picker and the value to set
                string parameter = $"{automationId}|{value}";
                app.Invoke("setFormsPickerValue:", parameter);

                if (showPicker)
                {
                    app.Tap(e => e.Text("Done"));
                }
            }
            else
            {
                throw new NotImplementedException("SetFormsPickerValue not imlemented for Android.");
            }
        }

        public static void SetFormsDatePickerValue(this IApp app, Platform platform, string automationId, DateTime value, bool showPicker = false)
        {
            if (platform == Platform.iOS)
            {
                if (showPicker)
                {
                    app.Tap(e => e.Id(automationId));
                }

                // Parse the date into a string format which can be used to create a DateTime at the other end
                string formattedDate = value.ToString("yyyy-MM-dd");

                // construct a parameter of the automationId of the Picker and the value to set
                string parameter = $"{automationId}|{formattedDate}";
                app.Invoke("setFormsDatePickerValue:", parameter);

                if (showPicker)
                {
                    app.Tap(e => e.Text("Done"));
                }
            }
            else
            {
                throw new NotImplementedException("SetFormsDatePickerValue not imlemented for Android.");
            }
        }
    }
}
